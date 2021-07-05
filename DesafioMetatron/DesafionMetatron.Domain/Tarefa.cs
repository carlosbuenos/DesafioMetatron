namespace DesafionMetatron.Domain
{
	public class Tarefa
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public bool Concluida { get; set; }
		public int ListaId { get; set; }
		public int UsuarioId { get; set; }
	}
}
