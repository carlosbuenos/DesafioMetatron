using DesafionMetatron.Domain.Builders.Interfaces;
using DesafionMetatron.Domain.Util;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DesafionMetatron.Domain
{
	public class Usuario
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }

		private List<bool> ListRegrasValidadas { get; set; }
		public Usuario()
		{
			ListRegrasValidadas = new List<bool>();
		}
		public bool EUmEmailValido()
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(Email);
				return addr.Address == Email;
			}
			catch
			{
				return false;
			}
		}

		public bool SenhaValida(IRegrasParaValidacaoDeSenha regras) 
		{
			ListRegrasValidadas.Add(regras.AoMenosUmCaractere(Senha));
			ListRegrasValidadas.Add(regras.AoMenosUmaLetraMaiuscula(Senha));
			ListRegrasValidadas.Add(regras.AoMenosUmaLetraMinuscula(Senha));
			ListRegrasValidadas.Add(regras.SemcaracteresDuplicados(Senha));
			ListRegrasValidadas.Add(regras.AoMenosUmcaractereEspecial(Senha));
			ListRegrasValidadas.Add(regras.NoMinimoNoveCaracteres(Senha));

			return ListRegrasValidadas.Contains(false) ? false : true;
		}

		public void CriptografarSenha()
		{

			Senha = Criptografia.CriptografarValor(Senha);
		}

		

	}
}
