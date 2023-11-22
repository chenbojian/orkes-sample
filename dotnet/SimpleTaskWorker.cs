
using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using Task = Conductor.Client.Models.Task;

public class SimpleWorker : IWorkflowTask
{
    public string TaskType { get; }
    public WorkflowTaskExecutorConfiguration WorkerSettings { get; }

    public SimpleWorker(string taskType = "bojian-test-sdk-csharp-task")
    {
        TaskType = taskType;
        WorkerSettings = new WorkflowTaskExecutorConfiguration();
    }

    public TaskResult Execute(Task task)
    {
        var taskResult = task.Completed(logs: new List<TaskExecLog>());
        taskResult.Logs.Add(new TaskExecLog(1, "log 1"));
        taskResult.Logs.Add(new TaskExecLog(2, "log 2"));
        taskResult.Logs.Add(new TaskExecLog(3, "log 3"));
        return taskResult;
    }
}