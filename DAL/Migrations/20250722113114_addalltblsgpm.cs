using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addalltblsgpm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armazem",
                columns: table => new
                {
                    armazemStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroArmazem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localizacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armazem", x => x.armazemStamp);
                });

            migrationBuilder.CreateTable(
                name: "ArtigoGeral",
                columns: table => new
                {
                    artigoGeralStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    um = table.Column<string>(name: "u_m", type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtigoGeral", x => x.artigoGeralStamp);
                });

            migrationBuilder.CreateTable(
                name: "Busca",
                columns: table => new
                {
                    buscaStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codBusca = table.Column<long>(type: "bigint", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numTabela = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busca", x => x.buscaStamp);
                });

            migrationBuilder.CreateTable(
                name: "Cat",
                columns: table => new
                {
                    CatStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codCategoria = table.Column<int>(type: "int", nullable: false),
                    codCat = table.Column<string>(type: "nvarchar(max)", maxLength: 20, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: false),
                    codRamo = table.Column<int>(type: "int", nullable: false),
                    ramo = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    classeMil = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat", x => x.CatStamp);
                });

            migrationBuilder.CreateTable(
                name: "CodCarta",
                columns: table => new
                {
                    codCartaStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodCarta", x => x.codCartaStamp);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    contratoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nrContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    descricaocontrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    abreviaturaFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.contratoStamp);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    cursoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codCurso = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo = table.Column<bool>(type: "bit", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    abreviatura = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.cursoStamp);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    distritoStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codDistrito = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    codProv = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    provinciaStamp = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.distritoStamp);
                });

            migrationBuilder.CreateTable(
                name: "Especial",
                columns: table => new
                {
                    especialStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codEspecial = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codRamo = table.Column<int>(type: "int", nullable: false),
                    ramo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especial", x => x.especialStamp);
                });

            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    especieStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    graus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.especieStamp);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    fornecedorStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    fornecedorNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fornecedorAbreviatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fornecedorContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.fornecedorStamp);
                });

            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    instituicaoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codInstituicao = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoInstituicao = table.Column<bool>(type: "bit", nullable: false),
                    codProvincia = table.Column<int>(type: "int", nullable: false),
                    provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codDistrito = table.Column<int>(type: "int", nullable: false),
                    distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codPostoAdm = table.Column<int>(type: "int", nullable: true),
                    postoAdm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.instituicaoStamp);
                });

            migrationBuilder.CreateTable(
                name: "Licenca",
                columns: table => new
                {
                    licencaStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codLicenca = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoLicenca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenca", x => x.licencaStamp);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermission",
                columns: table => new
                {
                    MenuPermissionsStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Only = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Except = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission", x => x.MenuPermissionsStamp);
                });

            migrationBuilder.CreateTable(
                name: "MenuTag",
                columns: table => new
                {
                    MenuTagStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTag", x => x.MenuTagStamp);
                });

            migrationBuilder.CreateTable(
                name: "Menuusr",
                columns: table => new
                {
                    Menuusrstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Menu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Userstamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuusr", x => x.Menuusrstamp);
                });

            migrationBuilder.CreateTable(
                name: "Mil",
                columns: table => new
                {
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nim = table.Column<long>(type: "bigint", nullable: false),
                    nascData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grupSangue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nacional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nascPais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nascProv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codNascProv = table.Column<int>(type: "int", nullable: false),
                    nascDist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codNascDist = table.Column<int>(type: "int", nullable: false),
                    nascPosto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codNascPostAdm = table.Column<int>(type: "int", nullable: false),
                    nascLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codNascLocalidade = table.Column<int>(type: "int", nullable: true),
                    nascPov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mae = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    regCasamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataCasamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    conjuge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numFilhos = table.Column<int>(type: "int", nullable: true),
                    habiLite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resProv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResProv = table.Column<int>(type: "int", nullable: false),
                    resDist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResDist = table.Column<int>(type: "int", nullable: false),
                    resPosto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResPostAdm = table.Column<int>(type: "int", nullable: false),
                    resLocalidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResLocal = table.Column<int>(type: "int", nullable: true),
                    resBairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resQuarteirao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resAvenida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numCasa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ramo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codRamo = table.Column<int>(type: "int", nullable: false),
                    incPais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    incProv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codIncProv = table.Column<int>(type: "int", nullable: false),
                    incDist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codIncDist = table.Column<int>(type: "int", nullable: false),
                    incPosto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codIncPostAdm = table.Column<int>(type: "int", nullable: true),
                    incLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codIncLocalidade = table.Column<int>(type: "int", nullable: true),
                    incData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inicioTreino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    terminoTreino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duracaoTreino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    centroTreino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cursoTreino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adquirEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mil", x => x.milStamp);
                });

            migrationBuilder.CreateTable(
                name: "Orgao",
                columns: table => new
                {
                    orgaoStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    codOrgao = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    organica = table.Column<int>(type: "int", nullable: false),
                    totalOf = table.Column<int>(type: "int", nullable: false),
                    totalOfGen = table.Column<int>(type: "int", nullable: false),
                    totalGenEx = table.Column<int>(type: "int", nullable: false),
                    totalTteGen = table.Column<int>(type: "int", nullable: false),
                    totalMajGen = table.Column<int>(type: "int", nullable: false),
                    totalBrigadeiro = table.Column<int>(type: "int", nullable: false),
                    totalOfSup = table.Column<int>(type: "int", nullable: false),
                    totalCor = table.Column<int>(type: "int", nullable: false),
                    totalTteCor = table.Column<int>(type: "int", nullable: false),
                    totalMaj = table.Column<int>(type: "int", nullable: false),
                    totalOfSub = table.Column<int>(type: "int", nullable: false),
                    totalCap = table.Column<int>(type: "int", nullable: false),
                    totalTte = table.Column<int>(type: "int", nullable: false),
                    totalTteMil = table.Column<int>(type: "int", nullable: false),
                    totalAlf = table.Column<int>(type: "int", nullable: false),
                    totalAlfMil = table.Column<int>(type: "int", nullable: false),
                    totalSarg = table.Column<int>(type: "int", nullable: false),
                    totalInt = table.Column<int>(type: "int", nullable: false),
                    totalSub = table.Column<int>(type: "int", nullable: false),
                    totalPriSar = table.Column<int>(type: "int", nullable: false),
                    totalSegSar = table.Column<int>(type: "int", nullable: false),
                    totalTerSar = table.Column<int>(type: "int", nullable: false),
                    totalFur = table.Column<int>(type: "int", nullable: false),
                    totalPra = table.Column<int>(type: "int", nullable: false),
                    totalPriCab = table.Column<int>(type: "int", nullable: false),
                    totalSegCab = table.Column<int>(type: "int", nullable: false),
                    totalSold = table.Column<int>(type: "int", nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgao", x => x.orgaoStamp);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    paisStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codPais = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    abreviatura = table.Column<string>(type: "nvarchar(max)", maxLength: 10, nullable: true),
                    nacional = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    pordefeito = table.Column<bool>(type: "bit", nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.paisStamp);
                });

            migrationBuilder.CreateTable(
                name: "Param",
                columns: table => new
                {
                    Paramstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Codprod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImprimeMultDocumento = table.Column<bool>(type: "bit", nullable: false),
                    CodprodMascra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendeservico = table.Column<bool>(type: "bit", nullable: false),
                    Ano = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prodenum = table.Column<bool>(type: "bit", nullable: false),
                    Ivcodentr = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ivdescentr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ivcodsai = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ivdescsai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usames = table.Column<bool>(type: "bit", nullable: false),
                    Contmascara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mostranib = table.Column<bool>(type: "bit", nullable: false),
                    Intervalo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fillvalue = table.Column<bool>(type: "bit", nullable: false),
                    MostraProdutoSemStock = table.Column<bool>(type: "bit", nullable: false),
                    Excluemascara = table.Column<bool>(type: "bit", nullable: false),
                    DiarioMesNum = table.Column<bool>(type: "bit", nullable: false),
                    DiarioDiamesnum = table.Column<bool>(type: "bit", nullable: false),
                    DiarioAnonum = table.Column<bool>(type: "bit", nullable: false),
                    CriaContacc = table.Column<bool>(type: "bit", nullable: false),
                    Usanumauto = table.Column<bool>(type: "bit", nullable: false),
                    Nummascara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mascfact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Radicalfact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actualizapreco = table.Column<bool>(type: "bit", nullable: false),
                    Montanumero = table.Column<bool>(type: "bit", nullable: false),
                    Tipooperacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumImpressao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Printfile = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Printfile2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Mostraendereco = table.Column<bool>(type: "bit", nullable: false),
                    Smtpserver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Smtpport = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Outgoingemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Outgoingpassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subjemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emailtext = table.Column<string>(type: "nvarchar(650)", maxLength: 650, nullable: false),
                    Autoprecos = table.Column<bool>(type: "bit", nullable: false),
                    Perlucro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Anoref = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Localrdlc = table.Column<bool>(type: "bit", nullable: false),
                    Usalocalreport = table.Column<bool>(type: "bit", nullable: false),
                    Criacl = table.Column<bool>(type: "bit", nullable: false),
                    Criafnc = table.Column<bool>(type: "bit", nullable: false),
                    Criast = table.Column<bool>(type: "bit", nullable: false),
                    Criacontas = table.Column<bool>(type: "bit", nullable: false),
                    Criacontasprazo = table.Column<bool>(type: "bit", nullable: false),
                    Criape = table.Column<bool>(type: "bit", nullable: false),
                    Ivaposdesconto = table.Column<bool>(type: "bit", nullable: false),
                    ContaIrps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContaIrpsdesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contaiva85 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contaiva85desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naomostradatain = table.Column<bool>(type: "bit", nullable: false),
                    Naomostradatater = table.Column<bool>(type: "bit", nullable: false),
                    Naomostraduracao = table.Column<bool>(type: "bit", nullable: false),
                    Naomostrasequencia = table.Column<bool>(type: "bit", nullable: false),
                    PoObrigatorio = table.Column<bool>(type: "bit", nullable: false),
                    PjFechoautomatico = table.Column<bool>(type: "bit", nullable: false),
                    TaxaInsspe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxaInssemp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Diastrab = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ponaorepete = table.Column<bool>(type: "bit", nullable: false),
                    Modeloja = table.Column<bool>(type: "bit", nullable: false),
                    Integracaoautomatica = table.Column<bool>(type: "bit", nullable: false),
                    Aredondamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Posicao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Totalinteiro = table.Column<bool>(type: "bit", nullable: false),
                    Mostraccusto = table.Column<bool>(type: "bit", nullable: false),
                    Integradocs = table.Column<bool>(type: "bit", nullable: false),
                    ObrigaNc = table.Column<bool>(type: "bit", nullable: false),
                    Codsrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codactivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duodessimos = table.Column<bool>(type: "bit", nullable: false),
                    Depmensais = table.Column<bool>(type: "bit", nullable: false),
                    Esconderef = table.Column<bool>(type: "bit", nullable: false),
                    Escondestock = table.Column<bool>(type: "bit", nullable: false),
                    Escondecolprecos = table.Column<bool>(type: "bit", nullable: false),
                    Preconormal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EcranPosPequeno = table.Column<bool>(type: "bit", nullable: false),
                    Mostrarefornec = table.Column<bool>(type: "bit", nullable: false),
                    Naoaredonda = table.Column<bool>(type: "bit", nullable: false),
                    Horastrab = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ObrigaBi = table.Column<bool>(type: "bit", nullable: false),
                    Segundavia = table.Column<bool>(type: "bit", nullable: false),
                    MostraTodasContas = table.Column<bool>(type: "bit", nullable: false),
                    Origem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GeraGuiaAutomatica = table.Column<bool>(type: "bit", nullable: false),
                    Anolectivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnoSem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mascaracl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usacademia = table.Column<bool>(type: "bit", nullable: false),
                    Dispensa = table.Column<bool>(type: "bit", nullable: false),
                    Exclui = table.Column<bool>(type: "bit", nullable: false),
                    MatriculaComCCaberto = table.Column<bool>(type: "bit", nullable: false),
                    Removematricula = table.Column<bool>(type: "bit", nullable: false),
                    NaoverificaNuit = table.Column<bool>(type: "bit", nullable: false),
                    EmailRespo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modulos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PermiteApagarPos = table.Column<bool>(type: "bit", nullable: false),
                    UsaMultRefereciaSt = table.Column<bool>(type: "bit", nullable: false),
                    UsaLotes = table.Column<bool>(type: "bit", nullable: false),
                    Campomultiuso = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Param", x => x.Paramstamp);
                });

            migrationBuilder.CreateTable(
                name: "ParamAno",
                columns: table => new
                {
                    ParamAnoStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ano = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    InseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    Alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    AlterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamAno", x => x.ParamAnoStamp);
                });

            migrationBuilder.CreateTable(
                name: "Pat",
                columns: table => new
                {
                    patStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codPatente = table.Column<int>(type: "int", nullable: false),
                    codPat = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: false),
                    codRamo = table.Column<int>(type: "int", nullable: false),
                    ramo = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    codCategoria = table.Column<int>(type: "int", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    classeMil = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    catStamp = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pat", x => x.patStamp);
                });

            migrationBuilder.CreateTable(
                name: "PermForm",
                columns: table => new
                {
                    permFormStamp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricaoNodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricaoNodoFilho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricaoNodoFilhoFILho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 30, nullable: false),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 30, nullable: false),
                    paStamp = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermForm", x => x.permFormStamp);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    permissaoStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nomeFormulario = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inserir = table.Column<bool>(type: "bit", nullable: false),
                    consultar = table.Column<bool>(type: "bit", nullable: false),
                    alterar = table.Column<bool>(type: "bit", nullable: false),
                    apagar = table.Column<bool>(type: "bit", nullable: false),
                    imprimir = table.Column<bool>(type: "bit", nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 30, nullable: false),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 30, nullable: false),
                    paStamp = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.permissaoStamp);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    provinciaStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codProv = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    paisStamp = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.provinciaStamp);
                });

            migrationBuilder.CreateTable(
                name: "QualifcTecnica",
                columns: table => new
                {
                    qualifcTecnicaStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codQualifTecnica = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grupoSalarial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nívelIV = table.Column<decimal>(name: "nível_IV", type: "decimal(18,2)", nullable: false),
                    nívelIII = table.Column<decimal>(name: "nível_III", type: "decimal(18,2)", nullable: false),
                    nívelII = table.Column<decimal>(name: "nível_II", type: "decimal(18,2)", nullable: false),
                    nívelI = table.Column<decimal>(name: "nível_I", type: "decimal(18,2)", nullable: false),
                    ComMaisde10anos = table.Column<decimal>(name: "Com_Mais_de_10_anos", type: "decimal(18,2)", nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualifcTecnica", x => x.qualifcTecnicaStamp);
                });

            migrationBuilder.CreateTable(
                name: "Ramo",
                columns: table => new
                {
                    RamoStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodRamo = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: true),
                    Organica = table.Column<int>(type: "int", nullable: false),
                    TotalOf = table.Column<int>(type: "int", nullable: false),
                    TotalOfGen = table.Column<int>(type: "int", nullable: false),
                    TotalGenEx = table.Column<int>(type: "int", nullable: false),
                    TotalTteGen = table.Column<int>(type: "int", nullable: false),
                    TotalMajGen = table.Column<int>(type: "int", nullable: false),
                    TotalBrigadeiro = table.Column<int>(type: "int", nullable: false),
                    TotalOfSup = table.Column<int>(type: "int", nullable: false),
                    TotalCor = table.Column<int>(type: "int", nullable: false),
                    TotalTteCor = table.Column<int>(type: "int", nullable: false),
                    TotalMaj = table.Column<int>(type: "int", nullable: false),
                    TotalOfSub = table.Column<int>(type: "int", nullable: false),
                    TotalCap = table.Column<int>(type: "int", nullable: false),
                    TotalTte = table.Column<int>(type: "int", nullable: false),
                    TotalTteMil = table.Column<int>(type: "int", nullable: false),
                    TotalAlf = table.Column<int>(type: "int", nullable: false),
                    TotalAlfMil = table.Column<int>(type: "int", nullable: false),
                    TotalSarg = table.Column<int>(type: "int", nullable: false),
                    TotalInt = table.Column<int>(type: "int", nullable: false),
                    TotalSub = table.Column<int>(type: "int", nullable: false),
                    TotalPriSar = table.Column<int>(type: "int", nullable: false),
                    TotalSegSar = table.Column<int>(type: "int", nullable: false),
                    TotalTerSar = table.Column<int>(type: "int", nullable: false),
                    TotalFur = table.Column<int>(type: "int", nullable: false),
                    TotalPra = table.Column<int>(type: "int", nullable: false),
                    TotalPriCab = table.Column<int>(type: "int", nullable: false),
                    TotalSegCab = table.Column<int>(type: "int", nullable: false),
                    TotalSold = table.Column<int>(type: "int", nullable: false),
                    Inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    InseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    Alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    AlterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ramo", x => x.RamoStamp);
                });

            migrationBuilder.CreateTable(
                name: "Reg",
                columns: table => new
                {
                    regStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codReg = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    abreviatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reg", x => x.regStamp);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    PaStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodUsuario = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriEntrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activopa = table.Column<bool>(type: "bit", nullable: false),
                    Inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InseriuDataHora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlterouDataHora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdaSic = table.Column<bool>(type: "bit", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direcao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orgaostamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamentostamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direcaostamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerSitClass = table.Column<bool>(type: "bit", nullable: false),
                    PathPdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TdocAniva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passwordexperaem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medico = table.Column<bool>(type: "bit", nullable: false),
                    Patentetegoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.PaStamp);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSessao",
                columns: table => new
                {
                    UsuarioSessaoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomeComputador = table.Column<string>(type: "nvarchar(max)", maxLength: 500, nullable: false),
                    NomeCompletoComputador = table.Column<string>(type: "nvarchar(max)", maxLength: 500, nullable: false),
                    WindowsEdition = table.Column<string>(type: "nvarchar(max)", maxLength: 500, nullable: false),
                    TipoComputador = table.Column<string>(type: "nvarchar(max)", maxLength: 350, nullable: false),
                    AdaptadorRede = table.Column<string>(type: "nvarchar(max)", maxLength: 500, nullable: false),
                    DataSessao = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    HoraSessaoEntrada = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: false),
                    DuracaoHora = table.Column<int>(type: "int", nullable: false),
                    DuracaoMin = table.Column<int>(type: "int", nullable: false),
                    DuracaoSegundos = table.Column<int>(type: "int", nullable: false),
                    HoraSessaoSaida = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    NomeUtilizador = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSessao", x => x.UsuarioSessaoStamp);
                });

            migrationBuilder.CreateTable(
                name: "Artigo",
                columns: table => new
                {
                    artigoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    artigoGeralStamp = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    codArtigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricaoartigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    artigogeral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    policiaMilitar = table.Column<bool>(type: "bit", nullable: true),
                    unidCerimonial = table.Column<bool>(type: "bit", nullable: true),
                    unifTrabalho = table.Column<bool>(type: "bit", nullable: true),
                    desportivo = table.Column<bool>(type: "bit", nullable: true),
                    domando = table.Column<bool>(type: "bit", nullable: true),
                    daraquedista = table.Column<bool>(type: "bit", nullable: true),
                    fuzileiro = table.Column<bool>(type: "bit", nullable: true),
                    piloto = table.Column<bool>(type: "bit", nullable: true),
                    complementar = table.Column<bool>(type: "bit", nullable: true),
                    ofGen = table.Column<bool>(type: "bit", nullable: true),
                    ofSup = table.Column<bool>(type: "bit", nullable: true),
                    ofSub = table.Column<bool>(type: "bit", nullable: true),
                    sargento = table.Column<bool>(type: "bit", nullable: true),
                    praca = table.Column<bool>(type: "bit", nullable: true),
                    norma = table.Column<int>(type: "int", nullable: false),
                    tempoUtil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tempoutilMesesAnos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artigo", x => x.artigoStamp);
                    table.ForeignKey(
                        name: "FK_Artigo_ArtigoGeral_artigoGeralStamp",
                        column: x => x.artigoGeralStamp,
                        principalTable: "ArtigoGeral",
                        principalColumn: "artigoGeralStamp");
                });

            migrationBuilder.CreateTable(
                name: "PostAdm",
                columns: table => new
                {
                    postAdmStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codPostoAdm = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    codDistrito = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: false),
                    distritoStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAdm", x => x.postAdmStamp);
                    table.ForeignKey(
                        name: "FK_PostAdm_Distrito_distritoStamp",
                        column: x => x.distritoStamp,
                        principalTable: "Distrito",
                        principalColumn: "distritoStamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubEspecial",
                columns: table => new
                {
                    subEspecialStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codSubespecial = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codEspecial = table.Column<int>(type: "int", nullable: false),
                    especialidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    especialStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubEspecial", x => x.subEspecialStamp);
                    table.ForeignKey(
                        name: "FK_SubEspecial_Especial_especialStamp",
                        column: x => x.especialStamp,
                        principalTable: "Especial",
                        principalColumn: "especialStamp");
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabelStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BadgeStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MenuPermissionsStamp = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuStamp);
                    table.ForeignKey(
                        name: "FK_Menu_MenuPermission_MenuPermissionsStamp",
                        column: x => x.MenuPermissionsStamp,
                        principalTable: "MenuPermission",
                        principalColumn: "MenuPermissionsStamp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_MenuTag_BadgeStamp",
                        column: x => x.BadgeStamp,
                        principalTable: "MenuTag",
                        principalColumn: "MenuTagStamp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_MenuTag_LabelStamp",
                        column: x => x.LabelStamp,
                        principalTable: "MenuTag",
                        principalColumn: "MenuTagStamp",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    emailStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codEmail = table.Column<int>(type: "int", nullable: false),
                    email1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.emailStamp);
                    table.ForeignKey(
                        name: "FK_Email_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilAgre",
                columns: table => new
                {
                    milAgreStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilAgre = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nascData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nascProv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codNascProv = table.Column<int>(type: "int", nullable: true),
                    resProv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResProv = table.Column<int>(type: "int", nullable: true),
                    resDist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResDist = table.Column<int>(type: "int", nullable: true),
                    resPosto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResPostAdm = table.Column<int>(type: "int", nullable: true),
                    resLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResLocal = table.Column<int>(type: "int", nullable: true),
                    resBairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<long>(type: "bigint", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilAgre", x => x.milAgreStamp);
                    table.ForeignKey(
                        name: "FK_MilAgre_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilConde",
                columns: table => new
                {
                    milCondeStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilConde = table.Column<int>(type: "int", nullable: false),
                    galardoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    especie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grauMedalha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataGalardoacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilConde", x => x.milCondeStamp);
                    table.ForeignKey(
                        name: "FK_MilConde_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilDoc",
                columns: table => new
                {
                    milDocStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilDoc = table.Column<int>(type: "int", nullable: false),
                    tipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localemissao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataemissao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datavalid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilDoc", x => x.milDocStamp);
                    table.ForeignKey(
                        name: "FK_MilDoc_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilEmail",
                columns: table => new
                {
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    emailStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilEmail", x => x.milStamp);
                    table.ForeignKey(
                        name: "FK_MilEmail_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilEmFor",
                columns: table => new
                {
                    milEmForStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilEmFor = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<bool>(type: "bit", nullable: false),
                    curso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adquirEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anoFrequentar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataTermino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duracaoNormal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nivelAtingir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoInstituicao = table.Column<bool>(type: "bit", nullable: false),
                    instituicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codPpais = table.Column<int>(type: "int", nullable: false),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codProvincia = table.Column<int>(type: "int", nullable: false),
                    provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codDistrito = table.Column<int>(type: "int", nullable: false),
                    distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codPostoAdm = table.Column<int>(type: "int", nullable: false),
                    postoAdm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codLocalidade = table.Column<int>(type: "int", nullable: false),
                    localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilEmFor", x => x.milEmForStamp);
                    table.ForeignKey(
                        name: "FK_MilEmFor_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilEspecial",
                columns: table => new
                {
                    milEspecialStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilEspecial = table.Column<int>(type: "int", nullable: false),
                    codRamo = table.Column<int>(type: "int", nullable: false),
                    ramo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codEspecial = table.Column<int>(type: "int", nullable: false),
                    especial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codSubEspecial = table.Column<int>(type: "int", nullable: true),
                    subEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    especialStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilEspecial", x => x.milEspecialStamp);
                    table.ForeignKey(
                        name: "FK_MilEspecial_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilFa",
                columns: table => new
                {
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilFa = table.Column<int>(type: "int", nullable: false),
                    falecData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    falecLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    circunstancias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enterroData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enterroLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numCampa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numCertObito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilFa", x => x.milStamp);
                    table.ForeignKey(
                        name: "FK_MilFa_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilFor",
                columns: table => new
                {
                    milForStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilFor = table.Column<int>(type: "int", nullable: false),
                    tipoFormacao = table.Column<bool>(type: "bit", nullable: false),
                    curso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataTermino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoInstituicao = table.Column<bool>(type: "bit", nullable: false),
                    instituicao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codPais = table.Column<int>(type: "int", nullable: false),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilFor", x => x.milForStamp);
                    table.ForeignKey(
                        name: "FK_MilFor_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilFot",
                columns: table => new
                {
                    milFotStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    caminho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilFot", x => x.milFotStamp);
                    table.ForeignKey(
                        name: "FK_MilFot_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilFuncao",
                columns: table => new
                {
                    milFuncaoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    codMilFuncao = table.Column<int>(type: "int", nullable: false),
                    funcao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataTermino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    orgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subunidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subunidade1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subunidade2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orgaoStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidadeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subunidadeStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subunidade1Stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subunidade2Stamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilFuncao", x => x.milFuncaoStamp);
                    table.ForeignKey(
                        name: "FK_MilFuncao_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilIDigital",
                columns: table => new
                {
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    caminhoPolegarE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    polegarE = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    caminhoIndicadorE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    indicadorE = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    caminhoPolegarD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    polegarD = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    caminhoIndicadorD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    indicadorD = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilIDigital", x => x.milStamp);
                    table.ForeignKey(
                        name: "FK_MilIDigital_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilLice",
                columns: table => new
                {
                    milLiceStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilLice = table.Column<int>(type: "int", nullable: false),
                    licenca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    licencaData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataTermino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    licencaStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilLice", x => x.milLiceStamp);
                    table.ForeignKey(
                        name: "FK_MilLice_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilLingua",
                columns: table => new
                {
                    milLinguaStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilLingua = table.Column<int>(type: "int", nullable: false),
                    lingua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fala = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    leitura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    escrita = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    compreensao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    materna = table.Column<bool>(type: "bit", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilLingua", x => x.milLinguaStamp);
                    table.ForeignKey(
                        name: "FK_MilLingua_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilMed",
                columns: table => new
                {
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMil = table.Column<int>(type: "int", nullable: false),
                    altura = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    braco = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    cabeca = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    pescoco = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    peito = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    cintura = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ancas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    entrepernas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    calcado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    peso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ombros = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilMed", x => x.milStamp);
                    table.ForeignKey(
                        name: "FK_MilMed_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilPeEmerg",
                columns: table => new
                {
                    milPeEmergStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilPeEmerg = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nascProv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codNascProv = table.Column<int>(type: "int", nullable: false),
                    resProv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResProv = table.Column<int>(type: "int", nullable: false),
                    resDist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResDist = table.Column<int>(type: "int", nullable: false),
                    resPosto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResPostAdm = table.Column<int>(type: "int", nullable: true),
                    resLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codResLocal = table.Column<int>(type: "int", nullable: true),
                    resBairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resAvenida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resQuarteirao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numCasa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilPeEmerg", x => x.milPeEmergStamp);
                    table.ForeignKey(
                        name: "FK_MilPeEmerg_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilProm",
                columns: table => new
                {
                    milPromStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilProm = table.Column<int>(type: "int", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoPromocao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    patStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilProm", x => x.milPromStamp);
                    table.ForeignKey(
                        name: "FK_MilProm_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilRea",
                columns: table => new
                {
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilRea = table.Column<int>(type: "int", nullable: false),
                    numOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    destino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilRea", x => x.milStamp);
                    table.ForeignKey(
                        name: "FK_MilRea_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilReco",
                columns: table => new
                {
                    milRecoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilReco = table.Column<int>(type: "int", nullable: false),
                    tipoDistincao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    concessaoDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilReco", x => x.milRecoStamp);
                    table.ForeignKey(
                        name: "FK_MilReco_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilReg",
                columns: table => new
                {
                    milRegStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codReg = table.Column<int>(type: "int", nullable: true),
                    dataReg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    regime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    regStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilReg", x => x.milRegStamp);
                    table.ForeignKey(
                        name: "FK_MilReg_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilRetReaSal",
                columns: table => new
                {
                    milRetReaSalStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilRetReaSal = table.Column<int>(type: "int", nullable: false),
                    sal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidadeSalario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    retencaoData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reactivacaoData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilRetReaSal", x => x.milRetReaSalStamp);
                    table.ForeignKey(
                        name: "FK_MilRetReaSal_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilSa",
                columns: table => new
                {
                    milSaStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilSa = table.Column<int>(type: "int", nullable: false),
                    doencaSofre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    doencaSofrida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cirurgiaSofrida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motivoDoenca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datainicioDoenca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilSa", x => x.milSaStamp);
                    table.ForeignKey(
                        name: "FK_MilSa_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilSalario",
                columns: table => new
                {
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    uCerimonial = table.Column<bool>(type: "bit", nullable: true),
                    saudeMilitar = table.Column<bool>(type: "bit", nullable: true),
                    recebePatente = table.Column<bool>(type: "bit", nullable: true),
                    recebeSqtc = table.Column<bool>(type: "bit", nullable: true),
                    escalao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sQTC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nivelSalarial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomeBanco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nrConta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilSalario", x => x.milStamp);
                    table.ForeignKey(
                        name: "FK_MilSalario_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilSit",
                columns: table => new
                {
                    milSitStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilSit = table.Column<int>(type: "int", nullable: false),
                    situacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilSit", x => x.milSitStamp);
                    table.ForeignKey(
                        name: "FK_MilSit_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilSitCrim",
                columns: table => new
                {
                    milSitCrimStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilSitCrim = table.Column<int>(type: "int", nullable: false),
                    orgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    infraccao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numProcesso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    processodata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detencaoData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    condenacaoData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localPrisao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    solturaData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numDocSoltura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilSitCrim", x => x.milSitCrimStamp);
                    table.ForeignKey(
                        name: "FK_MilSitCrim_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilSitDisc",
                columns: table => new
                {
                    milSitDiscStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilSitDisc = table.Column<int>(type: "int", nullable: false),
                    orgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    infracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numProcesso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataProcesso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    medTomadas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataInicioMedida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataTerminoMedida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilSitDisc", x => x.milSitDiscStamp);
                    table.ForeignKey(
                        name: "FK_MilSitDisc_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilSitQPActivo",
                columns: table => new
                {
                    milSitQPActivoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codMilSitQPActivo = table.Column<int>(type: "int", nullable: false),
                    situacaoQpAtivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localFuncao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilSitQPActivo", x => x.milSitQPActivoStamp);
                    table.ForeignKey(
                        name: "FK_MilSitQPActivo_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    telefoneStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone1 = table.Column<long>(type: "bigint", nullable: false),
                    milPeEmergStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.telefoneStamp);
                    table.ForeignKey(
                        name: "FK_Telefone_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    unidadeStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codUnidade = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    codOrgao = table.Column<int>(type: "int", nullable: false),
                    orgao = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: true),
                    cibm = table.Column<bool>(type: "bit", nullable: false),
                    estabEnsino = table.Column<bool>(type: "bit", nullable: false),
                    hospitalMilitar = table.Column<bool>(type: "bit", nullable: false),
                    unidSubordCentral = table.Column<bool>(type: "bit", nullable: false),
                    organica = table.Column<int>(type: "int", nullable: false),
                    totalOf = table.Column<int>(type: "int", nullable: false),
                    totalOfGen = table.Column<int>(type: "int", nullable: false),
                    totalGenEx = table.Column<int>(type: "int", nullable: false),
                    totalTteGen = table.Column<int>(type: "int", nullable: false),
                    totalMajGen = table.Column<int>(type: "int", nullable: false),
                    totalBrigadeiro = table.Column<int>(type: "int", nullable: false),
                    totalOfSup = table.Column<int>(type: "int", nullable: false),
                    totalCor = table.Column<int>(type: "int", nullable: false),
                    totalTteCor = table.Column<int>(type: "int", nullable: false),
                    totalMaj = table.Column<int>(type: "int", nullable: false),
                    totalOfSub = table.Column<int>(type: "int", nullable: false),
                    totalCap = table.Column<int>(type: "int", nullable: false),
                    totalTte = table.Column<int>(type: "int", nullable: false),
                    totalTteMil = table.Column<int>(type: "int", nullable: false),
                    totalAlf = table.Column<int>(type: "int", nullable: false),
                    totalAlfMil = table.Column<int>(type: "int", nullable: false),
                    totalSarg = table.Column<int>(type: "int", nullable: false),
                    totalInt = table.Column<int>(type: "int", nullable: false),
                    totalSub = table.Column<int>(type: "int", nullable: false),
                    totalPriSar = table.Column<int>(type: "int", nullable: false),
                    totalSegSar = table.Column<int>(type: "int", nullable: false),
                    totalTerSar = table.Column<int>(type: "int", nullable: false),
                    totalFur = table.Column<int>(type: "int", nullable: false),
                    totalPra = table.Column<int>(type: "int", nullable: false),
                    totalPriCab = table.Column<int>(type: "int", nullable: false),
                    totalSegCab = table.Column<int>(type: "int", nullable: false),
                    totalSold = table.Column<int>(type: "int", nullable: false),
                    provincia = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: true),
                    codProvincia = table.Column<int>(type: "int", nullable: true),
                    distrito = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: true),
                    codDistrito = table.Column<int>(type: "int", nullable: true),
                    postoAdm = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: true),
                    codPostoAdm = table.Column<int>(type: "int", nullable: true),
                    localidade = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: true),
                    codLocalidade = table.Column<int>(type: "int", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    orgaoStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pco = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.unidadeStamp);
                    table.ForeignKey(
                        name: "FK_Unidade_Orgao_orgaoStamp",
                        column: x => x.orgaoStamp,
                        principalTable: "Orgao",
                        principalColumn: "orgaoStamp");
                });

            migrationBuilder.CreateTable(
                name: "Paramemail",
                columns: table => new
                {
                    Paramemailstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Paramstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codtipo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paramemail", x => x.Paramemailstamp);
                    table.ForeignKey(
                        name: "FK_Paramemail_Param_Paramstamp",
                        column: x => x.Paramstamp,
                        principalTable: "Param",
                        principalColumn: "Paramstamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paramgct",
                columns: table => new
                {
                    Paramgctstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Paramstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Grupo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mascara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Padrao = table.Column<bool>(type: "bit", nullable: false),
                    Codtipo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paramgct", x => x.Paramgctstamp);
                    table.ForeignKey(
                        name: "FK_Paramgct_Param_Paramstamp",
                        column: x => x.Paramstamp,
                        principalTable: "Param",
                        principalColumn: "Paramstamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParamImp",
                columns: table => new
                {
                    ParamImpstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Paramstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Normal1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Normal2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ccusto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codccu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Padrao = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamImp", x => x.ParamImpstamp);
                    table.ForeignKey(
                        name: "FK_ParamImp_Param_Paramstamp",
                        column: x => x.Paramstamp,
                        principalTable: "Param",
                        principalColumn: "Paramstamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parampv",
                columns: table => new
                {
                    Parampvstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Paramstamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parampv", x => x.Parampvstamp);
                    table.ForeignKey(
                        name: "FK_Parampv_Param_Paramstamp",
                        column: x => x.Paramstamp,
                        principalTable: "Param",
                        principalColumn: "Paramstamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Escalao",
                columns: table => new
                {
                    escalaoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codEscalao = table.Column<int>(type: "int", nullable: false),
                    patente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    escalaoUcerm1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESCALÃOI = table.Column<string>(name: "ESCALÃO_I", type: "nvarchar(max)", nullable: true),
                    ESCALÃOII = table.Column<string>(name: "ESCALÃO_II", type: "nvarchar(max)", nullable: true),
                    ESCALÃOIII = table.Column<string>(name: "ESCALÃO_III", type: "nvarchar(max)", nullable: true),
                    ESCALÃOIV = table.Column<string>(name: "ESCALÃO_IV", type: "nvarchar(max)", nullable: true),
                    ESCALÃOV = table.Column<string>(name: "ESCALÃO_V", type: "nvarchar(max)", nullable: true),
                    obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    patStamp = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escalao", x => x.escalaoStamp);
                    table.ForeignKey(
                        name: "FK_Escalao_Pat_patStamp",
                        column: x => x.patStamp,
                        principalTable: "Pat",
                        principalColumn: "patStamp");
                });

            migrationBuilder.CreateTable(
                name: "ArtigoContrato",
                columns: table => new
                {
                    artigoContratoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    contratoStamp = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    tamanho = table.Column<int>(type: "int", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    artigoStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtigoContrato", x => x.artigoContratoStamp);
                    table.ForeignKey(
                        name: "FK_ArtigoContrato_Artigo_artigoStamp",
                        column: x => x.artigoStamp,
                        principalTable: "Artigo",
                        principalColumn: "artigoStamp");
                    table.ForeignKey(
                        name: "FK_ArtigoContrato_Contrato_contratoStamp",
                        column: x => x.contratoStamp,
                        principalTable: "Contrato",
                        principalColumn: "contratoStamp");
                });

            migrationBuilder.CreateTable(
                name: "Existencia",
                columns: table => new
                {
                    existenciaStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    artigoStamp = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    tamanho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantidadeActual = table.Column<int>(type: "int", nullable: false),
                    armazemStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Existencia", x => x.existenciaStamp);
                    table.ForeignKey(
                        name: "FK_Existencia_Artigo_artigoStamp",
                        column: x => x.artigoStamp,
                        principalTable: "Artigo",
                        principalColumn: "artigoStamp");
                });

            migrationBuilder.CreateTable(
                name: "Localidade",
                columns: table => new
                {
                    localidadeStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codLocalidade = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    codPostoAdm = table.Column<string>(type: "nvarchar(max)", maxLength: 50, nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    postAdmStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidade", x => x.localidadeStamp);
                    table.ForeignKey(
                        name: "FK_Localidade_PostAdm_postAdmStamp",
                        column: x => x.postAdmStamp,
                        principalTable: "PostAdm",
                        principalColumn: "postAdmStamp");
                });

            migrationBuilder.CreateTable(
                name: "MenuChildrenItems",
                columns: table => new
                {
                    MenuChildrenItemStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuPermissionsStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentMenuStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentItemStamp = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuChildrenItems", x => x.MenuChildrenItemStamp);
                    table.ForeignKey(
                        name: "FK_MenuChildrenItems_MenuChildrenItems_ParentItemStamp",
                        column: x => x.ParentItemStamp,
                        principalTable: "MenuChildrenItems",
                        principalColumn: "MenuChildrenItemStamp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuChildrenItems_MenuPermission_MenuPermissionsStamp",
                        column: x => x.MenuPermissionsStamp,
                        principalTable: "MenuPermission",
                        principalColumn: "MenuPermissionsStamp",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuChildrenItems_Menu_ParentMenuStamp",
                        column: x => x.ParentMenuStamp,
                        principalTable: "Menu",
                        principalColumn: "MenuStamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioMenus",
                columns: table => new
                {
                    PaStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MenuStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UsuarioMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtribuicao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioMenus", x => new { x.PaStamp, x.MenuStamp });
                    table.ForeignKey(
                        name: "FK_UsuarioMenus_Menu_MenuStamp",
                        column: x => x.MenuStamp,
                        principalTable: "Menu",
                        principalColumn: "MenuStamp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioMenus_Usuario_PaStamp",
                        column: x => x.PaStamp,
                        principalTable: "Usuario",
                        principalColumn: "PaStamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MilSubEspecial",
                columns: table => new
                {
                    milSubEspecialStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    milEspecialStamp = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubespecialStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataSubEspecial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    numOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilSubEspecial", x => x.milSubEspecialStamp);
                    table.ForeignKey(
                        name: "FK_MilSubEspecial_MilEspecial_milEspecialStamp",
                        column: x => x.milEspecialStamp,
                        principalTable: "MilEspecial",
                        principalColumn: "milEspecialStamp");
                });

            migrationBuilder.CreateTable(
                name: "Desconto",
                columns: table => new
                {
                    descontoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codDesconto = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentgDesconto = table.Column<int>(type: "int", nullable: false),
                    obsDesconto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desconto", x => x.descontoStamp);
                    table.ForeignKey(
                        name: "FK_Desconto_MilSalario_milStamp",
                        column: x => x.milStamp,
                        principalTable: "MilSalario",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "MilSalMensal",
                columns: table => new
                {
                    milSalMensalStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nim = table.Column<long>(type: "bigint", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    regime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    patente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    especialidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ano = table.Column<int>(type: "int", nullable: false),
                    bonusEspecial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    sQTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subsPosto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subSaudeMG95 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subSaudeTSS75 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subSaudeRisco15 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subSaudeSCET25 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subSaudeSEXC40 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    suplementoChefia25 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    suplementoSCET10 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    suplementoRisco15 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    forcaEspecial40 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    forcaEspecial50 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    forcaEspecial60 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    desconto2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    desconto7 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    liquidoActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    escalao1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    escalao2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    escalao3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    escalao4 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    escalao5 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subAlimentacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subTrinta30 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    outroSubsidio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalBonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    liquidoRecebe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    contaBanco = table.Column<long>(type: "bigint", nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilSalMensal", x => x.milSalMensalStamp);
                    table.ForeignKey(
                        name: "FK_MilSalMensal_MilSalario_milStamp",
                        column: x => x.milStamp,
                        principalTable: "MilSalario",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "Subsidio",
                columns: table => new
                {
                    subsidioStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codSubsidio = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentgSubsidio = table.Column<int>(type: "int", nullable: false),
                    obsSubsidio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsidio", x => x.subsidioStamp);
                    table.ForeignKey(
                        name: "FK_Subsidio_MilSalario_milStamp",
                        column: x => x.milStamp,
                        principalTable: "MilSalario",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "Suplemento",
                columns: table => new
                {
                    suplementoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codSuplemento = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    percentgSuplemento = table.Column<int>(type: "int", nullable: false),
                    obsSuplemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplemento", x => x.suplementoStamp);
                    table.ForeignKey(
                        name: "FK_Suplemento_MilSalario_milStamp",
                        column: x => x.milStamp,
                        principalTable: "MilSalario",
                        principalColumn: "milStamp");
                });

            migrationBuilder.CreateTable(
                name: "Subunidade",
                columns: table => new
                {
                    subunidadeStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codsubunidade = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    cibm = table.Column<bool>(type: "bit", nullable: false),
                    estabEnsino = table.Column<bool>(type: "bit", nullable: false),
                    unidSubordCentral = table.Column<bool>(type: "bit", nullable: false),
                    codUnidade = table.Column<int>(type: "int", nullable: false),
                    unidade = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    organica = table.Column<int>(type: "int", nullable: false),
                    totalOf = table.Column<int>(type: "int", nullable: false),
                    totalOfGen = table.Column<int>(type: "int", nullable: false),
                    totalGenEx = table.Column<int>(type: "int", nullable: false),
                    totalTteGen = table.Column<int>(type: "int", nullable: false),
                    totalMajGen = table.Column<int>(type: "int", nullable: false),
                    totalBrigadeiro = table.Column<int>(type: "int", nullable: false),
                    totalOfSup = table.Column<int>(type: "int", nullable: false),
                    totalCor = table.Column<int>(type: "int", nullable: false),
                    totalTteCor = table.Column<int>(type: "int", nullable: false),
                    totalMaj = table.Column<int>(type: "int", nullable: false),
                    totalOfSub = table.Column<int>(type: "int", nullable: false),
                    totalCap = table.Column<int>(type: "int", nullable: false),
                    totalTte = table.Column<int>(type: "int", nullable: false),
                    totalTteMil = table.Column<int>(type: "int", nullable: false),
                    totalAlf = table.Column<int>(type: "int", nullable: false),
                    totalAlfMil = table.Column<int>(type: "int", nullable: false),
                    totalSarg = table.Column<int>(type: "int", nullable: false),
                    totalInt = table.Column<int>(type: "int", nullable: false),
                    totalSub = table.Column<int>(type: "int", nullable: false),
                    totalPriSar = table.Column<int>(type: "int", nullable: false),
                    totalSegSar = table.Column<int>(type: "int", nullable: false),
                    totalTerSar = table.Column<int>(type: "int", nullable: false),
                    totalFur = table.Column<int>(type: "int", nullable: false),
                    totalPra = table.Column<int>(type: "int", nullable: false),
                    totalPriCab = table.Column<int>(type: "int", nullable: false),
                    totalSegCab = table.Column<int>(type: "int", nullable: false),
                    totalSold = table.Column<int>(type: "int", nullable: false),
                    zona = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: true),
                    provincia = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: true),
                    codProvincia = table.Column<int>(type: "int", nullable: false),
                    distrito = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: true),
                    codDistrito = table.Column<int>(type: "int", nullable: false),
                    postoAdm = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: true),
                    codPostoAdm = table.Column<int>(type: "int", nullable: false),
                    localidade = table.Column<string>(type: "nvarchar(max)", maxLength: 200, nullable: true),
                    codLocalidade = table.Column<int>(type: "int", nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    inseriuDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    alterouDataHora = table.Column<string>(type: "nvarchar(max)", maxLength: 100, nullable: true),
                    unidadeStamp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subunidade", x => x.subunidadeStamp);
                    table.ForeignKey(
                        name: "FK_Subunidade_Unidade_unidadeStamp",
                        column: x => x.unidadeStamp,
                        principalTable: "Unidade",
                        principalColumn: "unidadeStamp");
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    entradaStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    existenciaStamp = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    dataEntrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidadeStamp = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    orgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroGR = table.Column<int>(type: "int", nullable: false),
                    pUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    pTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    numeroContrato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroParaImpressao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.entradaStamp);
                    table.ForeignKey(
                        name: "FK_Entrada_Existencia_existenciaStamp",
                        column: x => x.existenciaStamp,
                        principalTable: "Existencia",
                        principalColumn: "existenciaStamp");
                    table.ForeignKey(
                        name: "FK_Entrada_Unidade_unidadeStamp",
                        column: x => x.unidadeStamp,
                        principalTable: "Unidade",
                        principalColumn: "unidadeStamp");
                });

            migrationBuilder.CreateTable(
                name: "Fornecimento",
                columns: table => new
                {
                    fornecimentoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    unidadeStamp = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    milStamp = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    existenciaStamp = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    subunidadeStamp = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    dataFornecimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroGR = table.Column<int>(type: "int", nullable: false),
                    jarecebeu = table.Column<bool>(type: "bit", nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeOrgaoUnidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecimento", x => x.fornecimentoStamp);
                    table.ForeignKey(
                        name: "FK_Fornecimento_Existencia_existenciaStamp",
                        column: x => x.existenciaStamp,
                        principalTable: "Existencia",
                        principalColumn: "existenciaStamp");
                    table.ForeignKey(
                        name: "FK_Fornecimento_Mil_milStamp",
                        column: x => x.milStamp,
                        principalTable: "Mil",
                        principalColumn: "milStamp");
                    table.ForeignKey(
                        name: "FK_Fornecimento_Subunidade_subunidadeStamp",
                        column: x => x.subunidadeStamp,
                        principalTable: "Subunidade",
                        principalColumn: "subunidadeStamp");
                    table.ForeignKey(
                        name: "FK_Fornecimento_Unidade_unidadeStamp",
                        column: x => x.unidadeStamp,
                        principalTable: "Unidade",
                        principalColumn: "unidadeStamp");
                });

            migrationBuilder.CreateTable(
                name: "Subunidade1",
                columns: table => new
                {
                    subunidade1Stamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codSubunidade1 = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subunidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codOrgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    organica = table.Column<int>(type: "int", nullable: false),
                    totalOfSup = table.Column<int>(type: "int", nullable: false),
                    totalCor = table.Column<int>(type: "int", nullable: false),
                    totalTteCor = table.Column<int>(type: "int", nullable: false),
                    totalMaj = table.Column<int>(type: "int", nullable: false),
                    totalOfSub = table.Column<int>(type: "int", nullable: false),
                    totalCap = table.Column<int>(type: "int", nullable: false),
                    totalTte = table.Column<int>(type: "int", nullable: false),
                    totalTteMil = table.Column<int>(type: "int", nullable: false),
                    totalAlf = table.Column<int>(type: "int", nullable: false),
                    totalAlfMil = table.Column<int>(type: "int", nullable: false),
                    totalSarg = table.Column<int>(type: "int", nullable: false),
                    totalInt = table.Column<int>(type: "int", nullable: false),
                    totalSub = table.Column<int>(type: "int", nullable: false),
                    totalPriSar = table.Column<int>(type: "int", nullable: false),
                    totalSegSar = table.Column<int>(type: "int", nullable: false),
                    totalTerSar = table.Column<int>(type: "int", nullable: false),
                    totalFur = table.Column<int>(type: "int", nullable: false),
                    totalPra = table.Column<int>(type: "int", nullable: false),
                    totalPriCab = table.Column<int>(type: "int", nullable: false),
                    totalSegCab = table.Column<int>(type: "int", nullable: false),
                    totalSold = table.Column<int>(type: "int", nullable: false),
                    provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codProvincia = table.Column<int>(type: "int", nullable: false),
                    distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codDistrito = table.Column<int>(type: "int", nullable: false),
                    postoAdm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codPostoAdm = table.Column<int>(type: "int", nullable: false),
                    localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codLocalidade = table.Column<int>(type: "int", nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    subunidadeStamp = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    totalOf = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subunidade1", x => x.subunidade1Stamp);
                    table.ForeignKey(
                        name: "FK_Subunidade1_Subunidade_subunidadeStamp",
                        column: x => x.subunidadeStamp,
                        principalTable: "Subunidade",
                        principalColumn: "subunidadeStamp");
                });

            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    fornecimentoStamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dataEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrega", x => x.fornecimentoStamp);
                    table.ForeignKey(
                        name: "FK_Entrega_Fornecimento_fornecimentoStamp",
                        column: x => x.fornecimentoStamp,
                        principalTable: "Fornecimento",
                        principalColumn: "fornecimentoStamp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subunidade2",
                columns: table => new
                {
                    subunidade2Stamp = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    codSubunidade2 = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subunidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subunidade1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codOrgao = table.Column<int>(type: "int", nullable: false),
                    orgao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    organica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalOf = table.Column<int>(type: "int", nullable: false),
                    totalOfSup = table.Column<int>(type: "int", nullable: false),
                    totalCor = table.Column<int>(type: "int", nullable: false),
                    totalTteCor = table.Column<int>(type: "int", nullable: false),
                    totalMaj = table.Column<int>(type: "int", nullable: false),
                    totalOfSub = table.Column<int>(type: "int", nullable: false),
                    totalCap = table.Column<int>(type: "int", nullable: false),
                    totalTte = table.Column<int>(type: "int", nullable: false),
                    totalTteMil = table.Column<int>(type: "int", nullable: false),
                    totalAlf = table.Column<int>(type: "int", nullable: false),
                    totalAlfMil = table.Column<int>(type: "int", nullable: false),
                    totalSarg = table.Column<int>(type: "int", nullable: false),
                    totalInt = table.Column<int>(type: "int", nullable: false),
                    totalSub = table.Column<int>(type: "int", nullable: false),
                    totalPriSar = table.Column<int>(type: "int", nullable: false),
                    totalSegSar = table.Column<int>(type: "int", nullable: false),
                    totalTerSar = table.Column<int>(type: "int", nullable: false),
                    totalFur = table.Column<int>(type: "int", nullable: false),
                    totalPra = table.Column<int>(type: "int", nullable: false),
                    totalPriCab = table.Column<int>(type: "int", nullable: false),
                    totalSegCab = table.Column<int>(type: "int", nullable: false),
                    totalSold = table.Column<int>(type: "int", nullable: false),
                    provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codProvincia = table.Column<int>(type: "int", nullable: false),
                    distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codDistrito = table.Column<int>(type: "int", nullable: false),
                    postoAdm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codPostoAdm = table.Column<int>(type: "int", nullable: false),
                    localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codLocalidade = table.Column<int>(type: "int", nullable: false),
                    inseriu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inseriuDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    alterou = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alterouDataHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    subunidade1Stamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subunidade11subunidade1Stamp = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subunidade2", x => x.subunidade2Stamp);
                    table.ForeignKey(
                        name: "FK_Subunidade2_Subunidade1_Subunidade11subunidade1Stamp",
                        column: x => x.Subunidade11subunidade1Stamp,
                        principalTable: "Subunidade1",
                        principalColumn: "subunidade1Stamp");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artigo_artigoGeralStamp",
                table: "Artigo",
                column: "artigoGeralStamp");

            migrationBuilder.CreateIndex(
                name: "IX_ArtigoContrato_artigoStamp",
                table: "ArtigoContrato",
                column: "artigoStamp");

            migrationBuilder.CreateIndex(
                name: "IX_ArtigoContrato_contratoStamp",
                table: "ArtigoContrato",
                column: "contratoStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Desconto_milStamp",
                table: "Desconto",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Email_milStamp",
                table: "Email",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_existenciaStamp",
                table: "Entrada",
                column: "existenciaStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_unidadeStamp",
                table: "Entrada",
                column: "unidadeStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Escalao_patStamp",
                table: "Escalao",
                column: "patStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Existencia_artigoStamp",
                table: "Existencia",
                column: "artigoStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecimento_existenciaStamp",
                table: "Fornecimento",
                column: "existenciaStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecimento_milStamp",
                table: "Fornecimento",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecimento_subunidadeStamp",
                table: "Fornecimento",
                column: "subunidadeStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecimento_unidadeStamp",
                table: "Fornecimento",
                column: "unidadeStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Localidade_postAdmStamp",
                table: "Localidade",
                column: "postAdmStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_BadgeStamp",
                table: "Menu",
                column: "BadgeStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_LabelStamp",
                table: "Menu",
                column: "LabelStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuPermissionsStamp",
                table: "Menu",
                column: "MenuPermissionsStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MenuChildrenItems_MenuPermissionsStamp",
                table: "MenuChildrenItems",
                column: "MenuPermissionsStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MenuChildrenItems_ParentItemStamp",
                table: "MenuChildrenItems",
                column: "ParentItemStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MenuChildrenItems_ParentMenuStamp",
                table: "MenuChildrenItems",
                column: "ParentMenuStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilAgre_milStamp",
                table: "MilAgre",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilConde_milStamp",
                table: "MilConde",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilDoc_milStamp",
                table: "MilDoc",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilEmFor_milStamp",
                table: "MilEmFor",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilEspecial_milStamp",
                table: "MilEspecial",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilFor_milStamp",
                table: "MilFor",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilFot_milStamp",
                table: "MilFot",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilFuncao_milStamp",
                table: "MilFuncao",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilLice_milStamp",
                table: "MilLice",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilLingua_milStamp",
                table: "MilLingua",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilPeEmerg_milStamp",
                table: "MilPeEmerg",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilProm_milStamp",
                table: "MilProm",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilReco_milStamp",
                table: "MilReco",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilReg_milStamp",
                table: "MilReg",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilRetReaSal_milStamp",
                table: "MilRetReaSal",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilSa_milStamp",
                table: "MilSa",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilSalMensal_milStamp",
                table: "MilSalMensal",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilSit_milStamp",
                table: "MilSit",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilSitCrim_milStamp",
                table: "MilSitCrim",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilSitDisc_milStamp",
                table: "MilSitDisc",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilSitQPActivo_milStamp",
                table: "MilSitQPActivo",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_MilSubEspecial_milEspecialStamp",
                table: "MilSubEspecial",
                column: "milEspecialStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Paramemail_Paramstamp",
                table: "Paramemail",
                column: "Paramstamp");

            migrationBuilder.CreateIndex(
                name: "IX_Paramgct_Paramstamp",
                table: "Paramgct",
                column: "Paramstamp");

            migrationBuilder.CreateIndex(
                name: "IX_ParamImp_Paramstamp",
                table: "ParamImp",
                column: "Paramstamp");

            migrationBuilder.CreateIndex(
                name: "IX_Parampv_Paramstamp",
                table: "Parampv",
                column: "Paramstamp");

            migrationBuilder.CreateIndex(
                name: "IX_PostAdm_distritoStamp",
                table: "PostAdm",
                column: "distritoStamp");

            migrationBuilder.CreateIndex(
                name: "IX_SubEspecial_especialStamp",
                table: "SubEspecial",
                column: "especialStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Subsidio_milStamp",
                table: "Subsidio",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Subunidade_unidadeStamp",
                table: "Subunidade",
                column: "unidadeStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Subunidade1_subunidadeStamp",
                table: "Subunidade1",
                column: "subunidadeStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Subunidade2_Subunidade11subunidade1Stamp",
                table: "Subunidade2",
                column: "Subunidade11subunidade1Stamp");

            migrationBuilder.CreateIndex(
                name: "IX_Suplemento_milStamp",
                table: "Suplemento",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_milStamp",
                table: "Telefone",
                column: "milStamp");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_orgaoStamp",
                table: "Unidade",
                column: "orgaoStamp");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMenus_MenuStamp",
                table: "UsuarioMenus",
                column: "MenuStamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armazem");

            migrationBuilder.DropTable(
                name: "ArtigoContrato");

            migrationBuilder.DropTable(
                name: "Busca");

            migrationBuilder.DropTable(
                name: "Cat");

            migrationBuilder.DropTable(
                name: "CodCarta");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Desconto");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Entrega");

            migrationBuilder.DropTable(
                name: "Escalao");

            migrationBuilder.DropTable(
                name: "Especie");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "Licenca");

            migrationBuilder.DropTable(
                name: "Localidade");

            migrationBuilder.DropTable(
                name: "MenuChildrenItems");

            migrationBuilder.DropTable(
                name: "Menuusr");

            migrationBuilder.DropTable(
                name: "MilAgre");

            migrationBuilder.DropTable(
                name: "MilConde");

            migrationBuilder.DropTable(
                name: "MilDoc");

            migrationBuilder.DropTable(
                name: "MilEmail");

            migrationBuilder.DropTable(
                name: "MilEmFor");

            migrationBuilder.DropTable(
                name: "MilFa");

            migrationBuilder.DropTable(
                name: "MilFor");

            migrationBuilder.DropTable(
                name: "MilFot");

            migrationBuilder.DropTable(
                name: "MilFuncao");

            migrationBuilder.DropTable(
                name: "MilIDigital");

            migrationBuilder.DropTable(
                name: "MilLice");

            migrationBuilder.DropTable(
                name: "MilLingua");

            migrationBuilder.DropTable(
                name: "MilMed");

            migrationBuilder.DropTable(
                name: "MilPeEmerg");

            migrationBuilder.DropTable(
                name: "MilProm");

            migrationBuilder.DropTable(
                name: "MilRea");

            migrationBuilder.DropTable(
                name: "MilReco");

            migrationBuilder.DropTable(
                name: "MilReg");

            migrationBuilder.DropTable(
                name: "MilRetReaSal");

            migrationBuilder.DropTable(
                name: "MilSa");

            migrationBuilder.DropTable(
                name: "MilSalMensal");

            migrationBuilder.DropTable(
                name: "MilSit");

            migrationBuilder.DropTable(
                name: "MilSitCrim");

            migrationBuilder.DropTable(
                name: "MilSitDisc");

            migrationBuilder.DropTable(
                name: "MilSitQPActivo");

            migrationBuilder.DropTable(
                name: "MilSubEspecial");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "ParamAno");

            migrationBuilder.DropTable(
                name: "Paramemail");

            migrationBuilder.DropTable(
                name: "Paramgct");

            migrationBuilder.DropTable(
                name: "ParamImp");

            migrationBuilder.DropTable(
                name: "Parampv");

            migrationBuilder.DropTable(
                name: "PermForm");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "QualifcTecnica");

            migrationBuilder.DropTable(
                name: "Ramo");

            migrationBuilder.DropTable(
                name: "Reg");

            migrationBuilder.DropTable(
                name: "SubEspecial");

            migrationBuilder.DropTable(
                name: "Subsidio");

            migrationBuilder.DropTable(
                name: "Subunidade2");

            migrationBuilder.DropTable(
                name: "Suplemento");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "UsuarioMenus");

            migrationBuilder.DropTable(
                name: "UsuarioSessao");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Fornecimento");

            migrationBuilder.DropTable(
                name: "Pat");

            migrationBuilder.DropTable(
                name: "PostAdm");

            migrationBuilder.DropTable(
                name: "MilEspecial");

            migrationBuilder.DropTable(
                name: "Param");

            migrationBuilder.DropTable(
                name: "Especial");

            migrationBuilder.DropTable(
                name: "Subunidade1");

            migrationBuilder.DropTable(
                name: "MilSalario");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Existencia");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "Subunidade");

            migrationBuilder.DropTable(
                name: "Mil");

            migrationBuilder.DropTable(
                name: "MenuPermission");

            migrationBuilder.DropTable(
                name: "MenuTag");

            migrationBuilder.DropTable(
                name: "Artigo");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "ArtigoGeral");

            migrationBuilder.DropTable(
                name: "Orgao");
        }
    }
}
