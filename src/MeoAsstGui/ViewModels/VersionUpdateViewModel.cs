// <copyright file="VersionUpdateViewModel.cs" company="MaaAssistantArknights">
// MeoAsstGui - A part of the MeoAssistantArknights project
// Copyright (C) 2021 MistEO and Contributors
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stylet;
using StyletIoC;

namespace MeoAsstGui
{
    /// <summary>
    /// The view model of version update.
    /// </summary>
    public class VersionUpdateViewModel : Screen
    {
        private readonly IWindowManager _windowManager;
        private readonly IContainer _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionUpdateViewModel"/> class.
        /// </summary>
        /// <param name="container">The IoC container.</param>
        /// <param name="windowManager">The window manager.</param>
        public VersionUpdateViewModel(IContainer container, IWindowManager windowManager)
        {
            _container = container;
            _windowManager = windowManager;
        }

        [DllImport("MeoAssistant.dll")]
        private static extern IntPtr AsstGetVersion();

        private static string AddContributorLink(string text)
        {
            /*
            //        "@ " -> "@ "
            //       "`@`" -> "`@`"
            //   "@MistEO" -> "[@MistEO](https://github.com/MistEO)"
            // "[@MistEO]" -> "[@MistEO]"
            */
            return Regex.Replace(text, @"([^\[`]|^)@([^\s]+)", "$1[@$2](https://github.com/$2)");
        }

        private readonly string _curVersion = Marshal.PtrToStringAnsi(AsstGetVersion());
        private string _latestVersion;

        private string _updateTag = ViewStatusStorage.Get("VersionUpdate.name", string.Empty);

        /// <summary>
        /// Gets or sets the update tag.
        /// </summary>
        public string UpdateTag
        {
            get => _updateTag;
            set
            {
                SetAndNotify(ref _updateTag, value);
                ViewStatusStorage.Set("VersionUpdate.name", value);
            }
        }

        private string _updateInfo = ViewStatusStorage.Get("VersionUpdate.body", string.Empty);

        // private static readonly MarkdownPipeline s_markdownPipeline = new MarkdownPipelineBuilder().UseXamlSupportedExtensions().Build();

        /// <summary>
        /// Gets or sets the update info.
        /// </summary>
        public string UpdateInfo
        {
            get
            {
                try
                {
                    return AddContributorLink(_updateInfo);
                }
                catch
                {
                    return _updateInfo;
                }
            }

            set
            {
                SetAndNotify(ref _updateInfo, value);
                ViewStatusStorage.Set("VersionUpdate.body", value);
            }
        }

        private string _updateUrl;

        /// <summary>
        /// Gets or sets the update URL.
        /// </summary>
        public string UpdateUrl
        {
            get => _updateUrl;
            set => SetAndNotify(ref _updateUrl, value);
        }

        /*
        public FlowDocument UpdateInfoDocument
        {
            get
            {
                try
                {
                    return MarkdownXaml.ToFlowDocument(UpdateInfo, s_markdownPipeline);
                }
                catch (Exception)
                {
                    // ?????????????????????????????????????????????????????? MarkdownXaml ?????????????????? crash
                    // ???????????????????????????
                    try
                    {
                        return new MdXaml.Markdown().Transform(UpdateInfo);
                    }
                    catch (Exception)
                    {
                        return new FlowDocument();
                    }
                }
            }
        }
        */

        /// <summary>
        /// Gets a value indicating whether it is the first boot after updating.
        /// </summary>
        public bool IsFirstBootAfterUpdate => UpdateTag != string.Empty && UpdateTag == _curVersion;

        private string _updatePackageName = ViewStatusStorage.Get("VersionUpdate.package", string.Empty);

        /// <summary>
        /// Gets or sets the name of the update package.
        /// </summary>
        public string UpdatePackageName
        {
            get => _updatePackageName;
            set
            {
                SetAndNotify(ref _updatePackageName, value);
                ViewStatusStorage.Set("VersionUpdate.package", value);
            }
        }

        private const string RequestUrl = "https://api.github.com/repos/MaaAssistantArknights/MaaAssistantArknights/releases";
        private const string RequestUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.99 Safari/537.36 Edg/97.0.1072.76";
        private JObject _latestJson;
        private JObject _assetsObject;

        /// <summary>
        /// ??????????????????????????????????????????????????????????????????????????????
        /// </summary>
        /// <returns>?????????????????? <see langword="true"/>?????????????????? <see langword="false"/>???</returns>
        public bool CheckAndUpdateNow()
        {
            if (UpdateTag == string.Empty
                || UpdatePackageName == string.Empty
                || !File.Exists(UpdatePackageName))
            {
                return false;
            }

            Execute.OnUIThread(() =>
            {
                using (var toast = new ToastNotification("?????????????????????"))
                {
                    toast.AppendContentText("??????????????????????????????")
                        .AppendContentText(UpdateTag)
                        .ShowUpdateVersion(row: 2);
                }
            });

            string extractDir = Directory.GetCurrentDirectory() + "\\NewVersionExtract";

            // ??????
            try
            {
                if (Directory.Exists(extractDir))
                {
                    Directory.Delete(extractDir, true);
                }

                System.IO.Compression.ZipFile.ExtractToDirectory(UpdatePackageName, extractDir);
            }
            catch (InvalidDataException)
            {
                File.Delete(UpdatePackageName);
                Execute.OnUIThread(() =>
                {
                    using (var toast = new ToastNotification("????????????????????????"))
                    {
                        toast.AppendContentText("?????????: " + UpdatePackageName)
                            .AppendContentText("??????????????????")
                            .ShowUpdateVersion();
                    }
                });
                return false;
            }

            var uncopiedList = new List<string>();

            // ????????????????????????????????????????????????
            foreach (var file in Directory.GetFiles(extractDir))
            {
                try
                {
                    File.Copy(file, Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(file)), true);
                }
                catch (Exception)
                {
                    uncopiedList.Add(file);
                }
            }

            foreach (var directory in Directory.GetDirectories(extractDir))
            {
                CopyFilesRecursively(directory, Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(directory)));
            }

            // ??????????????????????????????????????????????????????????????????????????????
            // ??????????????????????????????????????????????????????????????????
            foreach (var oldFile in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.old"))
            {
                File.Delete(oldFile);
            }

            foreach (var file in uncopiedList)
            {
                string curFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(file));
                File.Move(curFileName, curFileName + ".old");
                File.Copy(file, curFileName);
            }

            // ???????????????????????????????????????
            Directory.Delete(extractDir, true);
            File.Delete(UpdatePackageName);

            // ?????????????????????????????????????????????????????????????????????
            UpdatePackageName = string.Empty;
            ViewStatusStorage.Save();

            // ???????????????????????????????????????????????????
            var newProcess = new Process();
            newProcess.StartInfo.FileName = AppDomain.CurrentDomain.FriendlyName;
            newProcess.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            newProcess.Start();
            Application.Current.Shutdown();

            return true;
        }

        /// <summary>
        /// ????????????????????????????????????
        /// </summary>
        /// <param name="force">?????????????????????</param>
        /// <returns>?????????????????? <see langword="true"/>?????????????????? <see langword="false"/>???</returns>
        public bool CheckAndDownloadUpdate(bool force = false)
        {
            // ????????????
            if (!CheckUpdate(force))
            {
                return false;
            }

            // ????????????????????????
            UpdatePackageName = _assetsObject["name"]?.ToString();
            UpdateTag = _latestJson["name"]?.ToString();
            UpdateInfo = _latestJson["body"]?.ToString();
            UpdateUrl = _latestJson["html_url"]?.ToString();

            // ToastNotification.get= _latestJson["html_url"].ToString();
            var openUrlToastButton = (
                text: "??????????????????",
                action: new Action(() =>
                {
                    if (!string.IsNullOrWhiteSpace(_latestJson["html_url"]?.ToString()))
                    {
                        Process.Start(_latestJson["html_url"].ToString());
                    }
                }));

            if (_container.Get<SettingsViewModel>().AutoDownloadUpdatePackage)
            {
                Execute.OnUIThread(() =>
                {
                    using (var toast = new ToastNotification("??????????????????"))
                    {
                        toast.ButtonSystemUrl = UpdateUrl;
                        toast.AppendContentText("????????????????????????")
                            .AppendContentText("?????????: " + UpdateTag)
                            .AppendContentText("????????????: " + UpdateInfo)
                            .AddButtonLeft(openUrlToastButton.text, openUrlToastButton.action)
                            .ShowUpdateVersion();
                    }
                });
            }
            else
            {
                Execute.OnUIThread(() =>
                {
                    using (var toast = new ToastNotification("??????????????????"))
                    {
                        toast.ButtonSystemUrl = UpdateUrl;
                        toast.AppendContentText("?????????: " + UpdateTag)
                            .AppendContentText("????????????: " + UpdateInfo)
                            .AddButtonLeft(openUrlToastButton.text, openUrlToastButton.action)
                            .ShowUpdateVersion();
                    }
                });
                return false;
            }

            // ???????????????
            const int DownloadRetryMaxTimes = 3;
            var downloaded = false;
            for (int i = 0; i < DownloadRetryMaxTimes; i++)
            {
                var mirroredAssets = (JObject)_assetsObject.DeepClone();
                mirroredAssets.Property("browser_download_url")?.Remove();
                mirroredAssets.Add("browser_download_url", _assetsObject["browser_download_url"]?.ToString().Replace("github.com", "download.fastgit.org"));
                if (DownloadGithubAssets(mirroredAssets) || DownloadGithubAssets(_assetsObject))
                {
                    downloaded = true;
                    break;
                }
            }

            if (!downloaded)
            {
                Execute.OnUIThread(() =>
                {
                    using (var toast = new ToastNotification("?????????????????????"))
                    {
                        toast.ButtonSystemUrl = UpdateUrl;
                        toast.AppendContentText("??????????????????????????????????????????????????????_(:????????)_")
                            .AddButtonLeft(openUrlToastButton.text, openUrlToastButton.action)
                            .Show();
                    }
                });
                return false;
            }

            // ???????????????????????????????????????????????????????????????
            Execute.OnUIThread(() =>
            {
                using (var toast = new ToastNotification("?????????????????????"))
                {
                    toast.AppendContentText("??????????????????????????????????????????")
                        .AppendContentText("?????????(???????)??????")
                        .ShowUpdateVersion(row: 3);
                }
            });

            return true;
        }

        /// <summary>
        /// ???????????????
        /// </summary>
        /// <param name="force">?????????????????????</param>
        /// <returns>?????????????????? <see langword="true"/>?????????????????? <see langword="false"/>???</returns>
        public bool CheckUpdate(bool force = false)
        {
            // ????????????????????????
            if (!force && !isStableVersion())
            {
                return false;
            }

            var settings = _container.Get<SettingsViewModel>();
            if (!settings.UpdateCheck)
            {
                return false;
            }

            const int RequestRetryMaxTimes = 5;
            var response = RequestApi(RequestUrl);
            for (int i = 0; response.Length == 0 && i < RequestRetryMaxTimes; i++)
            {
                response = RequestApi(RequestUrl);
            }

            if (response.Length == 0)
            {
                return false;
            }

            try
            {
                var releaseArray = JsonConvert.DeserializeObject(response) as JArray;

                foreach (var item in releaseArray)
                {
                    if ((bool)item["prerelease"])
                    {
                        if (settings.UpdateBeta)
                        {
                            _latestJson = item as JObject;
                            break;
                        }
                    }
                    else
                    {
                        _latestJson = item as JObject;
                        break;
                    }
                }

                _latestVersion = _latestJson["tag_name"].ToString();
                if (ViewStatusStorage.Get("VersionUpdate.Ignore", string.Empty) == _latestVersion)
                {
                    return false;
                }

                Semver.SemVersion curVersionObj;
                bool curParsed = Semver.SemVersion.TryParse(_curVersion, Semver.SemVersionStyles.AllowLowerV, out curVersionObj);
                Semver.SemVersion latestVersionObj;
                bool latestPared = Semver.SemVersion.TryParse(_latestVersion, Semver.SemVersionStyles.AllowLowerV, out latestVersionObj);
                if (curParsed && latestPared)
                {
                    if (curVersionObj.CompareSortOrderTo(latestVersionObj) >= 0)
                    {
                        return false;
                    }
                }
                else if (string.CompareOrdinal(_curVersion, _latestVersion) >= 0)
                {
                    return false;
                }

                if (!_latestJson.ContainsKey("assets")
                    || (_latestJson["assets"] as JArray).Count == 0)
                {
                    return false;
                }

                _assetsObject = _latestJson["assets"][0] as JObject;
                foreach (var curAssets in _latestJson["assets"] as JArray)
                {
                    var name = curAssets["name"].ToString();
                    if (name.ToLower().Contains("ota"))
                    {
                        _assetsObject = curAssets as JObject;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ?????? API
        /// </summary>
        /// <param name="url">API ??????</param>
        /// <returns>?????? API ???????????????????????????????????????????????????</returns>
        private string RequestApi(string url)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.UserAgent = RequestUserAgent;
                httpWebRequest.Accept = "application/vnd.github.v3+json";
                var settings = _container.Get<SettingsViewModel>();
                if (settings.Proxy.Length > 0)
                {
                    httpWebRequest.Proxy = new WebProxy(settings.Proxy);
                }

                var httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                var streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
                var responseContent = streamReader.ReadToEnd();
                streamReader.Close();
                httpWebResponse.Close();
                return responseContent;
            }
            catch (Exception info)
            {
                Console.WriteLine(info.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// ?????? GitHub Assets ?????????????????????
        /// </summary>
        /// <param name="assetsObject">Github Assets ??????</param>
        /// <param name="downloader">????????????????????????????????? CSharp ??????????????????</param>
        /// <param name="saveTo">??????????????????????????????????????????????????????</param>
        /// <returns>?????????????????? true?????????????????? false</returns>
        public bool DownloadGithubAssets(JObject assetsObject, string downloader = null, string saveTo = null)
        {
            return DownloadFile(
                url: assetsObject["browser_download_url"].ToString(),
                fileName: assetsObject["name"].ToString(), contentType:
                assetsObject["content_type"].ToString(),
                downloader: downloader,
                saveTo: saveTo);
        }

        /// <summary>
        /// ??????????????????????????????
        /// </summary>
        /// <param name="url">??????????????????</param>
        /// <param name="fileName">?????????????????????????????????</param>
        /// <param name="contentType">????????????????????????????????????</param>
        /// <param name="downloader">????????????????????????????????? CSharp ??????????????????</param>
        /// <param name="saveTo">??????????????????????????????????????????????????????</param>
        /// <returns>?????????????????? <see langword="true"/>?????????????????? <see langword="false"/>???</returns>
        public bool DownloadFile(string url, string fileName, string contentType = null, string downloader = null, string saveTo = null)
        {
            string usedDownloader;
            string filePath;
            bool returned;

            if (saveTo != null)
            {
                filePath = Path.GetFullPath(saveTo);
            }
            else
            {
                filePath = Directory.GetCurrentDirectory();
            }

            if (downloader != null)
            {
                usedDownloader = downloader;
            }
            else
            {
                usedDownloader = _container.Get<SettingsViewModel>().UseAria2 ? "ARIA2" : "NATIVE";
            }

            var fileNameWithTemp = fileName + ".temp";
            var fullFilePath = Path.GetFullPath(filePath + "/" + fileName);
            var fullFilePathWithTemp = Path.GetFullPath(filePath + "/" + fileNameWithTemp);

            try
            {
                if (usedDownloader == "ARIA2")
                {
                    returned = DownloadFileForAria2(url: url, filePath: filePath, fileName: fileNameWithTemp);
                }
                else
                {
                    // ?????????????????????????????????????????? Native ????????????
                    returned = DownloadFileForCSharpNative(url: url, filePath: fullFilePathWithTemp, contentType: contentType);
                }
            }
            catch (Exception info)
            {
                Console.WriteLine(info.Message);
                returned = false;
            }

            if (returned)
            {
                // ???????????????
                File.Copy(fullFilePathWithTemp, fullFilePath, true);
                File.Delete(fullFilePathWithTemp);
                return true;
            }
            else
            {
                // ?????????????????????
                File.Delete(fullFilePathWithTemp);
                return false;
            }
        }

        private bool DownloadFileForAria2(string url, string filePath, string fileName)
        {
            var aria2FilePath = Path.GetFullPath(Directory.GetCurrentDirectory() + "/aria2c.exe");
            var aria2Args = "\"" + url + "\" --continue=true --dir=\"" + filePath + "\" --out=\"" + fileName + "\" --user-agent=\"" + RequestUserAgent + "\"";

            var settings = _container.Get<SettingsViewModel>();
            if (settings.Proxy.Length > 0)
            {
                aria2Args += " --all-proxy=\"" + settings.Proxy + "\"";
            }

            var aria2Process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = aria2FilePath,
                    Arguments = aria2Args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                },
                EnableRaisingEvents = true,
            };

            aria2Process.Start();
            aria2Process.WaitForExit();
            var exit_code = aria2Process.ExitCode;
            aria2Process.Close();
            return exit_code == 0;
        }

        private bool DownloadFileForCSharpNative(string url, string filePath, string contentType = null)
        {
            // ?????? Http ??????
            var httpWebRequest = WebRequest.Create(url) as HttpWebRequest;

            // ??????????????????
            var settings = _container.Get<SettingsViewModel>();
            httpWebRequest.Method = "GET";
            httpWebRequest.UserAgent = RequestUserAgent;
            if (contentType != null)
            {
                httpWebRequest.Accept = contentType;
            }

            if (settings.Proxy.Length > 0)
            {
                httpWebRequest.Proxy = new WebProxy(settings.Proxy);
            }

            // ????????? HttpWebResponse
            var httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;

            // ?????????????????????
            var responseStream = httpWebResponse.GetResponseStream();
            var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            // ??????????????????
            var byteArray = new byte[1024];
            var byteArraySize = responseStream.Read(byteArray, 0, byteArray.Length);
            while (byteArraySize > 0)
            {
                fileStream.Write(byteArray, 0, byteArraySize);
                byteArraySize = responseStream.Read(byteArray, 0, byteArray.Length);
            }

            // ?????????
            responseStream.Close();
            fileStream.Close();

            return true;
        }

        private bool isStableVersion()
        {
            // ????????????vX.X.X
            // DevBuild (CI)???yyyy-MM-dd-HH-mm-ss-{CommitHash[..7]}
            // DevBuild (Local)???yyyy-MM-dd-HH-mm-ss-{CommitHash[..7]}-Local
            // Release (Local Commit)???v.{CommitHash[..7]}-Local
            // Release (Local Tag)???{Tag}-Local
            // Debug (Local)???DEBUG VERSION
            // Script Compiled???c{CommitHash[..7]}
            if (_curVersion == "DEBUG VERSION")
            {
                return false;
            }

            if (_curVersion.StartsWith("c"))
            {
                return false;
            }

            if (_curVersion.Contains("Local"))
            {
                return false;
            }

            var pattern = @"v((0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?)";
            var match = Regex.Match(_curVersion, pattern);
            if (match.Success is false)
            {
                return false;
            }

            return true;
        }

        // ???????????????????????? OTA ?????????????????????????????????????????????
        // ????????? OTA ?????????????????????????????????
        // public bool ResourceOTA(bool force = false)
        // {
        //    // ????????????????????????
        //    if (!force && !isStableVersion())
        //    {
        //        return false;
        //    }

        // const string req_base_url = "https://api.github.com/repos/MaaAssistantArknights/MaaAssistantArknights/commits?path=";
        //    const string repositorie_base = "MaaAssistantArknights/MaaAssistantArknights";
        //    const string branche_base = "master";

        // // cdn???????????????
        //    // new string[]
        //    // {
        //    //      ??????????????????,
        //    //      ???????????????????????????: {0}???????????????, {1}??? sha ???
        //    // }
        //    var down_base_url = new List<string[]>() {
        //         new string[]{$"https://cdn.jsdelivr.net/gh/{repositorie_base}@" , "{1}/{0}" },
        //         new string[]{$"https://pd.zwc365.com/seturl/https://raw.githubusercontent.com/{repositorie_base}/{branche_base}/" , "{0}?{1}" },
        //         new string[]{$"https://cdn.staticaly.com/gh/{repositorie_base}/{branche_base}/" , "{0}?{1}" },
        //         new string[]{$"https://ghproxy.fsou.cc/https://github.com/{repositorie_base}/blob/{branche_base}/" , "{0}?{1}" },
        //    };

        // // ??????????????????????????????????????????????????????????????????????????????????????????dict
        //    var update_dict = new Dictionary<string, string>()
        //    {
        //        { "resource/stages.json" , "resource/stages.json"},
        //        { "resource/recruit.json", "resource/recruit.json" },
        //        { "3rdparty/resource/Arknights-Tile-Pos/levels.json" , "resource/Arknights-Tile-Pos/levels.json"},
        //        { "resource/item_index.json", "resource/item_index.json" }
        //    };

        // bool updated = false;
        //    string message = string.Empty;

        // foreach (var item in update_dict)
        //    {
        //        string url = item.Key;
        //        string filename = item.Value;

        // string cur_sha = ViewStatusStorage.Get(filename, string.Empty);

        // string response = RequestApi(req_base_url + url);
        //        if (string.IsNullOrWhiteSpace(response))
        //        {
        //            continue;
        //        }
        //        string cloud_sha;
        //        string cur_message = string.Empty;
        //        try
        //        {
        //            JArray arr = (JArray)JsonConvert.DeserializeObject(response);
        //            JObject commit_info = (JObject)arr[0];
        //            cloud_sha = commit_info["sha"].ToString();
        //            cur_message = commit_info["commit"]["message"].ToString();
        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }

        // if (cur_sha == cloud_sha)
        //        {
        //            continue;
        //        }

        // bool downloaded = false;
        //        string tempname = filename + ".tmp";
        //        foreach (var down_item in down_base_url)
        //        {
        //            var download_url = down_item[0];
        //            var download_args_format = down_item[1];

        // download_url += string.Format(download_args_format, url, cloud_sha);
        //            if (DownloadFile(download_url, tempname, downloader: "NATIVE"))
        //            {
        //                downloaded = true;
        //                break;
        //            }
        //        }

        // if (!downloaded)
        //        {
        //            continue;
        //        }

        // string tmp = File.ReadAllText(tempname).Replace("\r\n", "\n");

        // try
        //        {
        //            JsonConvert.DeserializeObject(tmp);
        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }

        // string src = File.ReadAllText(filename).Replace("\r\n", "\n");
        //        if (src.Length != tmp.Length)
        //        {
        //            File.Copy(tempname, filename, true);
        //            updated = true;
        //            message += cur_message + "\n";
        //        }
        //        // ??????????????? sha ???????????????
        //        ViewStatusStorage.Set(filename, cloud_sha);
        //        File.Delete(tempname);
        //    }

        // if (!updated)
        //    {
        //        return false;
        //    }

        // Execute.OnUIThread(() =>
        //    {
        //        using (var toast = new ToastNotification("???????????????"))
        //        {
        //            toast.AppendContentText("?????????????????????")
        //                .AppendContentText(message)
        //                .ShowUpdateVersion();
        //        }
        //    });

        // return true;
        // }
        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            Directory.CreateDirectory(targetPath);

            // Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            // Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        /// <summary>
        /// Closes view model.
        /// </summary>
        public void Close()
        {
            RequestClose();
            UpdateTag = string.Empty;
            UpdateInfo = string.Empty;
        }

        /// <summary>
        /// The event handler of opening hyperlink.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public void OpenHyperlink(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Process.Start(e.Parameter.ToString());
        }
    }
}
