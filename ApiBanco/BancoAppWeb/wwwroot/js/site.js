
    function confirmarAcao() {
        var resposta = confirm("Tem certeza que deseja executar esta ação?");
    if (resposta == true) {
            // Código a ser executado se o usuário clicar em "OK"
            location.replace("https://localhost:7160");
            return true;
        } else {
            // Código a ser executado se o usuário clicar em "Cancelar"
            return false;
        }
    }
