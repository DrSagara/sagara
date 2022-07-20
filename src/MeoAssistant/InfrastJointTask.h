#pragma once
#include "InfrastAbstractTask.h"

namespace asst
{
    class InfrastJointTask : public InfrastAbstractTask
    {
    public:
        using InfrastAbstractTask::InfrastAbstractTask;
        virtual ~InfrastJointTask() = default;

    protected:
        virtual bool _run() override;
    };
}
