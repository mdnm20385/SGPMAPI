namespace DAL.Classes
{
    public  class ProgressReport
    {
        public int ProcessComplete { get; set; }
        public int Total { get; set; }
        public int Actual { get; set; }
        public string Descricao { get; set; }
        public string Processo { get; set; }
    }
}
