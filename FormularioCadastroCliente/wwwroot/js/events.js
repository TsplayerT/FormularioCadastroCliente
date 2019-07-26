function preenchido(str) {
    return str === null || str != null && str.match(/^ *$/) !== null;
}

function validar() {
    var RazaoSocial = document.getElementById("RazaoSocial").value;
    var NomeFantasia = document.getElementById("NomeFantasia").value;
    var Cnpj = document.getElementById("Cnpj").value;
    var DataAberturaEmpresa = document.getElementById("DataAberturaEmpresa").value;
    var Endereco = document.getElementById("Endereco").value;
    var Bairro = document.getElementById("Bairro").value;
    var Cidade = document.getElementById("Cidade").value;
    var Uf = document.getElementById("UF").value;

    if (preenchido(RazaoSocial) || preenchido(NomeFantasia) || preenchido(Cnpj) || preenchido(DataAberturaEmpresa) || preenchido(Endereco) || preenchido(Bairro) || preenchido(Cidade) || preenchido(Uf)) {
        Swal.fire({
            title: "Por favor preencha todos os campos.",
            type: "info",
            padding: "2em",
            backdrop: "rgba(0, 0, 0, 0.5)"
        });
    }
    else if (!validarCNPJ(Cnpj)) {
        Swal.fire({
            title: "Por favor, insira um CNPJ válido!",
            type: "info",
            padding: "2em",
            backdrop: "rgba(0, 0, 0, 0.5)"
        });
    }
    else if (!validarData(DataAberturaEmpresa)) {
        Swal.fire({
            title: "Por favor, insira uma data válida!",
            type: "info",
            padding: "2em",
            backdrop: "rgba(0, 0, 0, 0.5)"
        });
    } else {
        Swal.fire({
            title: "Cliente registrado com sucesso!",
            type: "success",
            padding: "2em",
            backdrop: "rgba(0, 0, 0, 0.5)"
        }).then(() => {
            location.reload();
        });
    }
    return false;
}
function validarCNPJ(cnpj) {

    cnpj = cnpj.replace(/[^\d]+/g, "");

    if (preenchido(cnpj)) {
        return false;
    }

    if (cnpj.length !== 14) {
        return false;
    }

    var tamanho = cnpj.length - 2;
    var numeros = cnpj.substring(0, tamanho);
    var digitos = cnpj.substring(tamanho);
    var soma = 0;
    var pos = tamanho - 7;

    for (var x = tamanho; x >= 1; x--) {
        soma += numeros.charAt(tamanho - x) * pos--;
        if (pos < 2)
            pos = 9;
    }

    var resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado.toString() !== digitos.charAt(0).toString()) {
        return false;
    }

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;

    for (var i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }

    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;

    return resultado.toString() === digitos.charAt(1).toString();
}
function validarData(data) {
    var reg = /(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d/;
    if (!data.toString().match(reg)) {
        return false;
    }
    var partesData = data.split("/");
    var dataFormatada = new Date(partesData[2], partesData[1] - 1, partesData[0]);

    return new Date() > dataFormatada;
}