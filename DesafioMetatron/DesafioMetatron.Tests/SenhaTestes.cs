using DesafionMetatron.Domain.Builders.ConcreteObjects;
using DesafionMetatron.Domain.Builders.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace DesafioMetatron.Tests
{
	public class SenhaTestes
	{
		private readonly IRegrasParaValidacaoDeSenha _regrasParaValidacaoDeSenha;
		public SenhaTestes()
		{
			_regrasParaValidacaoDeSenha = new RegrasParaValidacaoDeSenha();
		}

		[Fact]
		public void ValidationsFalse_1()
		{
			const string value = "";
			var resultList = new List<bool>();
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmCaractere(value));
			resultList.Add(_regrasParaValidacaoDeSenha.SemcaracteresDuplicados(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMinuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmcaractereEspecial(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMaiuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.NoMinimoNoveCaracteres(value));

			Assert.Equal(false, !resultList.Contains(false));
		}


		[Fact]
		public void ValidationsFalse_2()
		{
			const string value = "aa";
			var resultList = new List<bool>();
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmCaractere(value));
			resultList.Add(_regrasParaValidacaoDeSenha.SemcaracteresDuplicados(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMinuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmcaractereEspecial(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMaiuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.NoMinimoNoveCaracteres(value));

			Assert.Equal(false, !resultList.Contains(false));
		}

		[Fact]
		public void ValidationsFalse_3()
		{
			const string value = "ab";
			var resultList = new List<bool>();
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmCaractere(value));
			resultList.Add(_regrasParaValidacaoDeSenha.SemcaracteresDuplicados(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMinuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmcaractereEspecial(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMaiuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.NoMinimoNoveCaracteres(value));

			Assert.Equal(false, !resultList.Contains(false));
		}

		[Fact]
		public void ValidationsFalse_4()
		{
			const string value = "AAAbbbCc";
			var resultList = new List<bool>();
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmCaractere(value));
			resultList.Add(_regrasParaValidacaoDeSenha.SemcaracteresDuplicados(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMinuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmcaractereEspecial(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMaiuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.NoMinimoNoveCaracteres(value));

			Assert.Equal(false, !resultList.Contains(false));
		}

		[Fact]
		public void ValidationsFalse_5()
		{
			const string value = "AbTp9!foo";
			var resultList = new List<bool>();
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmCaractere(value));
			resultList.Add(_regrasParaValidacaoDeSenha.SemcaracteresDuplicados(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMinuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmcaractereEspecial(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMaiuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.NoMinimoNoveCaracteres(value));

			Assert.Equal(false, !resultList.Contains(false));
		}

		[Fact]
		public void ValidationsFalse_6()
		{
			const string value = "AbTp9!foA";
			var resultList = new List<bool>();
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmCaractere(value));
			resultList.Add(_regrasParaValidacaoDeSenha.SemcaracteresDuplicados(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMinuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmcaractereEspecial(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMaiuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.NoMinimoNoveCaracteres(value));

			Assert.Equal(false, !resultList.Contains(false));
		}
		[Fact]
		public void ValidationsFalse_7()
		{
			const string value = "AbTp9 fok";
			var resultList = new List<bool>();
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmCaractere(value));
			resultList.Add(_regrasParaValidacaoDeSenha.SemcaracteresDuplicados(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMinuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmcaractereEspecial(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMaiuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.NoMinimoNoveCaracteres(value));

			Assert.Equal(false, !resultList.Contains(false));
		}

		[Fact]
		public void ValidationsTrue_1()
		{
			const string value = "AbTp9!fok";
			var resultList = new List<bool>();
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmCaractere(value));
			resultList.Add(_regrasParaValidacaoDeSenha.SemcaracteresDuplicados(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMinuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmcaractereEspecial(value));
			resultList.Add(_regrasParaValidacaoDeSenha.AoMenosUmaLetraMaiuscula(value));
			resultList.Add(_regrasParaValidacaoDeSenha.NoMinimoNoveCaracteres(value));

			Assert.Equal(true, !resultList.Contains(false));
		}
	}
}
