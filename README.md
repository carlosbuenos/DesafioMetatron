# DesafioMetatron

o projeto está conectadoa uma base online.</br>
É só baixar e rodar que automaticamente já irá abrir a página do swagger.
na pagina do swagger foi configurado a capácidade de enviar tokens no header.</br></br>


A controller de usuario não está bloqueada por autenticação para facilitar a utilização sem um front end,
nela é possivel consultar, cadastrar e gerar token para um usuario. todos os outros metodos estão protegidos por autenticação,
sendo necessario ter um token gerado e inmformado via header o padrão é Bearer.




