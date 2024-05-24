namespace CsUtil.MyLogger
{
    public partial class TaskLogger  
    {
        /// <summary>
        /// シリアライズする用のデータ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="logs"></param> <summary>
        /// 
        /// </summary>
        /// <typeparam name="string"></typeparam>
        private class TaskLoggerProperties(string name, HashSet<string> logs)
        {

            public string Name { get; set;} = name;
            public HashSet<string> Logs { get; set;} = logs;

            public TaskLoggerProperties() : this("", []){}

        }

    }

}