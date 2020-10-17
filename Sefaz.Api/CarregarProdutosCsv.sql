CREATE TABLE "ProdutoFalso" (
	"CodigoGtin"	INTEGER NOT NULL,
	"DataEmissao"	text NOT NULL,
	"CodigoTipoPagamento"	INTEGER NOT NULL,
	"CodigoProduto"	INTEGER,
	"CodigoNcm"	INTEGER,
	"CodigoUnidade"	text,
	"DescricaoProduto"	TEXT,
	"ValorUnitario"	INTEGER,
	"EstabelecimentoId"	INTEGER,
	"NomeEstabelecimento"	TEXT,
	"NomeLogradouro"	TEXT,
	"CodigoNumLogradouro"	INTEGER,
	"Complemento"	TEXT,
	"NomeBairro"	TEXT,
	"CodigoMunicipioIbge"	INTEGER,
	"NomeMunicipio"	TEXT,
	"NomeSiglaUf"	TEXT,
	"CodigoCep"	INTEGER,
	"NumeroLatitude"	text,
	"NumeroLongitude"	text
);

CREATE TABLE "Produto" (
	"ProdutoId" INTEGER NOT NULL,
	"CodigoGtin"	INTEGER NOT NULL,
	"DataEmissao"	text NOT NULL,
	"CodigoTipoPagamento"	INTEGER NOT NULL,
	"CodigoProduto"	INTEGER,
	"CodigoNcm"	INTEGER,
	"CodigoUnidade"	text,
	"DescricaoProduto"	TEXT,
	"ValorUnitario"	INTEGER,
	"EstabelecimentoId"	INTEGER,
	"NomeEstabelecimento"	TEXT,
	"NomeLogradouro"	TEXT,
	"CodigoNumLogradouro"	INTEGER,
	"Complemento"	TEXT,
	"NomeBairro"	TEXT,
	"CodigoMunicipioIbge"	INTEGER,
	"NomeMunicipio"	TEXT,
	"NomeSiglaUf"	TEXT,
	"CodigoCep"	INTEGER,
	"NumeroLatitude"	text,
	"NumeroLongitude"	text,
	 PRIMARY key (ProdutoId)
);

.mode csv
.import sefaz.csv ProdutoFalso

delete from ProdutoFalso where CodigoGtin like '%COD_GTIN%';

insert into Produto (CodigoGtin,DataEmissao,CodigoTipoPagamento,CodigoProduto,CodigoNcm,CodigoUnidade,
DescricaoProduto,ValorUnitario,EstabelecimentoId,NomeEstabelecimento,NomeLogradouro,
CodigoNumLogradouro,Complemento,NomeBairro,CodigoMunicipioIbge,NomeMunicipio,NomeSiglaUf,CodigoCep,
NumeroLatitude,NumeroLongitude) 
select CodigoGtin,DataEmissao,CodigoTipoPagamento,CodigoProduto,CodigoNcm,CodigoUnidade,DescricaoProduto,
ValorUnitario,EstabelecimentoId,NomeEstabelecimento,NomeLogradouro,
CodigoNumLogradouro,Complemento,NomeBairro,CodigoMunicipioIbge,NomeMunicipio,NomeSiglaUf,CodigoCep,NumeroLatitude,
NumeroLongitude from ProdutoFalso;

drop table IF EXISTS ProdutoFalso;