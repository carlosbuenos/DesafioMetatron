namespace DesafionMetatron.Domain.Builders.Interfaces
{
	public interface IRegrasParaValidacaoDeSenha
	{
		public bool AoMenosUmCaractere(string Value);
		public bool AoMenosUmaLetraMaiuscula(string Value);
		public bool AoMenosUmaLetraMinuscula(string Value);
		public bool AoMenosUmcaractereEspecial(string Value);
		public bool SemcaracteresDuplicados(string Value);
		public bool NoMinimoNoveCaracteres(string Value);
	}
}
