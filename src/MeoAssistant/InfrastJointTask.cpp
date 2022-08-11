#include "InfrastJointTask.h"

#include <meojson/json.hpp>

#include "RuntimeStatus.h"
#include "Logger.hpp"

bool asst::InfrastJointTask::_run()
{
    LogTraceFunction;

    json::value additional = json::parse(
        m_status->get_str(
            RuntimeStatus::InfrastAdditionalOverview).value_or(
                json::value().to_string()))
        .value_or(json::value());

    json::value efficiency = json::parse(
        m_status->get_str(
            RuntimeStatus::InfrastEfficiencyOverview).value_or(
                json::value().to_string()))
        .value_or(json::value());

    Log.info(__FUNCTION__, "| Additional:\n", additional.format());
    Log.info(__FUNCTION__, "| Efficiency:\n", efficiency.format());

    return false;
}
