﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace UDBCommon
{
    public static class TaskManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static CancellationTokenSource TaskCancellationToken = new CancellationTokenSource();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void CancelTasks(string message = "")
        {
            //if (!string.IsNullOrEmpty(message))
            //    TaskManager.TaskCancellationToken.Token.Register(() =>
            //    {
            //        MessageBox.Show(message);
            //    }, true);
            TaskManager.TaskCancellationToken.Cancel();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void AddCancel()
        {
            //TaskManager.TaskCancellationToken.Token.ThrowIfCancellationRequested();
            if (TaskManager.TaskCancellationToken.IsCancellationRequested)
                throw new OperationCanceledException(TaskManager.TaskCancellationToken.Token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskStart"></param>
        /// <param name="taskDone"></param>
        /// <param name="handleException"></param>
        /// <param name="scheduler"></param>
        public static Task NewTask(System.Action taskStart, System.Action taskDone = null, Action<AggregateException> handleException = null, TaskScheduler scheduler = null)
        {
            if (TaskManager.TaskCancellationToken.IsCancellationRequested)
                TaskManager.TaskCancellationToken = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(taskStart, TaskCancellationToken.Token);

            if (taskDone != null)
                task.ContinueWith(t => taskDone, CancellationToken.None,
                  TaskContinuationOptions.OnlyOnRanToCompletion,
                  scheduler);

            if (handleException != null)
                task.ContinueWith(t => handleException(t.Exception), CancellationToken.None,
                  TaskContinuationOptions.OnlyOnFaulted, scheduler);

            return task;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="taskStart"></param>
        /// <param name="taskDone"></param>
        /// <param name="handleException"></param>
        /// <param name="scheduler"></param>
        public static Task<T> NewTask<T>(Func<T> taskStart, Action<T> taskDone = null, Action<AggregateException> handleException = null, TaskScheduler scheduler = null)
        {
            if (TaskManager.TaskCancellationToken.IsCancellationRequested)
                TaskManager.TaskCancellationToken = new CancellationTokenSource();
            Task<T> task = Task<T>.Factory.StartNew(taskStart, TaskCancellationToken.Token);

            if (taskDone != null)
                task.ContinueWith(t => taskDone(t.Result), CancellationToken.None,
                  TaskContinuationOptions.OnlyOnRanToCompletion,
                  scheduler);

            if (handleException != null)
                task.ContinueWith(t => handleException(t.Exception), CancellationToken.None,
                  TaskContinuationOptions.OnlyOnFaulted, scheduler);

            return task;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="taskStart"></param>
        /// <param name="taskDone"></param>
        /// <param name="handleException"></param>
        /// <param name="scheduler"></param>
        public static void DoTask<T>(Func<T> taskStart, Action<T> taskDone = null, Action<AggregateException> handleException = null, TaskScheduler scheduler = null)
        {
            if (TaskManager.TaskCancellationToken.IsCancellationRequested)
                TaskManager.TaskCancellationToken = new CancellationTokenSource();
            Task<T> task = Task<T>.Factory.StartNew(taskStart, TaskCancellationToken.Token);

            if (taskDone != null)
                task.ContinueWith(t => taskDone(t.Result), CancellationToken.None,
                  TaskContinuationOptions.OnlyOnRanToCompletion,
                  scheduler);

            if (handleException != null)
                task.ContinueWith(t => handleException(t.Exception), CancellationToken.None,
                  TaskContinuationOptions.OnlyOnFaulted, scheduler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="sender"></param>
        public static void OutputException(this AggregateException exception, object sender)
        {
            //foreach (Exception innerException in exception.InnerExceptions)
            //{
            //    NotificationManager.SendOutput(
            //       sender,
            //       Icons.Error,
            //       new OutputEventArgs.OutputCategory(Global.GetString(sender.GetType(), "Exception")),
            //      innerException.Message);
            //    ConfirmationForm.Show(Confirmations.Generic, ConfirmationButtons.Ok,
            //        SystemIcons.Error,
            //        Global.GetString(typeof(TaskManager), "Error"),
            //        innerException.Message,
            //        null,
            //        innerException.Message);
            //}
        }
    }
}
