BEGIN TRANSACTION;
DROP TABLE IF EXISTS "Produto";
CREATE TABLE IF NOT EXISTS "Produto" (
	"ProdutoId"	INTEGER NOT NULL,
	"CodigoGTIN"	INTEGER NOT NULL,
	"DataEmissao"	INTEGER NOT NULL,
	"CodigoTipoPagamento"	INTEGER NOT NULL,
	"CodigoProduto"	INTEGER NOT NULL,
	"CodigoNCM"	INTEGER NOT NULL,
	"CodigoUnidade"	TEXT,
	"DescricaoProduto"	TEXT,
	"ValorUnitario"	TEXT NOT NULL,
	"EstabelecimentoId"	INTEGER NOT NULL,
	"NomeEstabelecimento"	TEXT,
	"NomeLogradouro"	TEXT,
	"CodigoNumLogradouro"	INTEGER NOT NULL,
	"Complemento"	TEXT,
	"NomeBairro"	REAL,
	"CodigoMunicipioIBGE"	INTEGER NOT NULL,
	"NomeMunicipio"	TEXT,
	"NomeSiglaUF"	TEXT,
	"CodigoCep"	INTEGER NOT NULL,
	"NumeroLatitude"	TEXT,
	"NumeroLongitude"	TEXT,
	CONSTRAINT "PK_Product" PRIMARY KEY("ProdutoId" AUTOINCREMENT)
);
COMMIT;
