namespace MeoAssistant.Core.Wrappers
{
    using System;
    using System.Runtime.InteropServices;

    public abstract class CppObject : IDisposable
    {
        private bool disposed;

        public CppObject(IntPtr pointer)
        {
            this.Pointer = pointer;
        }

        ~CppObject()
        {
            this.Dispose(false);
        }

        public IntPtr Pointer { get; set; }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [DllImport("MeoAssistant.Wrapper.dll", EntryPoint = "free")]
        private static extern void Free(IntPtr ptr);

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Release managed resources
                }

                // Release unmanaged resources
                Free(this.Pointer);
                this.Pointer = IntPtr.Zero;

                this.disposed = true;
            }
        }
    }
}
