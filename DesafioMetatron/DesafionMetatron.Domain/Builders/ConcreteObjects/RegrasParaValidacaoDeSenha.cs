using DesafionMetatron.Domain.Builders.Interfaces;
using System.Text.RegularExpressions;

namespace DesafionMetatron.Domain.Builders.ConcreteObjects
{
	public class RegrasParaValidacaoDeSenha : IRegrasParaValidacaoDeSenha
	{
		private Regex _regra;

		public bool AoMenosUmaLetraMaiuscula(string Value)
		{
			_regra = new Regex(@"(?=.*[A-Z])"); 
			return _regra.IsMatch(Value);
		}

		public bool AoMenosUmaLetraMinuscula(string Value)
		{
			_regra = new Regex(@"(?=.*[a-z])");
			return _regra.IsMatch(Value);
		}

		public bool AoMenosUmCaractere(string Value)
		{
			return string.IsNullOrEmpty(Value) ? false : true;
		}

		public bool AoMenosUmcaractereEspecial(string Value)
		{
			_regra = new Regex(@"(.*[!@#$%^&*()-+^&*()/\\])");
			return _regra.IsMatch(Value);
		}

		public bool NoMinimoNoveCaracteres(string Value)
		{
			_regra = new Regex(@"(.{9,})");
			return _regra.IsMatch(Value);
		}

		public bool SemcaracteresDuplicados(string Value)
		{
			_regra = new Regex(@"(\w)*.*\1");
			var temDuplicidade = _regra.IsMatch(Value);
			return temDuplicidade ? false : true;
		}
	}
}
