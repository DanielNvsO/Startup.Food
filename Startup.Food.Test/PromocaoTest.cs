using System;
using Xunit;
using Startup.Food.Repositorio.Entidade;
using System.Collections.Generic;
using Startup.Food.Repositorio.Interface;
using Startup.Food.Repositorio.Negocio.Promocao;
using Startup.Food.Repositorio.Negocio;

namespace Startup.Food.Test
{
    public class PromocaoTest
    {

        public EntidadeLanche Lanche { get; set; }

        [Theory]
        [MemberData(nameof(DadosLanchesComIngredientes.Lanches), MemberType = typeof(DadosLanchesComIngredientes))]
        public void RetornaPromocaoCorreta(EntidadeLanche lanche, string PromocaoEsperada ,Decimal ValorDesconto)
        {
            ServicePromocao Promocao = new ServicePromocao();

            IPromocao Light = new Light();

            Promocao.CalcularPromocao(lanche, Light);

            Object.Equals(Promocao.NomePromocao, PromocaoEsperada);
            Object.Equals(Promocao.Valor, ValorDesconto);

        }
    }
    public class DadosLanchesComIngredientes
    {
        public static IEnumerable<object[]> Lanches =>
            new List<object[]>
            {
            new object[] {
                new EntidadeLanche { Codigo= "X-Bacon",
                                        Descricao = "X-Bacon",
                                        Valor =Decimal.Parse("3.40") ,
                                        Ingredientes = 
                                        new List<EntidadeIngrediente> { new EntidadeIngrediente { Codigo="Alface",
                                                                                                    Quantidade =1,
                                                                                                    Valor =Decimal.Parse("0.40")
                                                                                                 },
                                                                        new EntidadeIngrediente { Codigo="Bacon",
                                                                                                    Quantidade=0,
                                                                                                    Valor =Decimal.Parse("2.00")
                                                                                                    },
                                                                        new EntidadeIngrediente { Codigo="HambCarn",
                                                                                                    Quantidade=1,
                                                                                                    Valor =Decimal.Parse("3.00")
                                                                                                    }
                                                                        }
                        },"Light",Decimal.Parse("3.16")
                },
            new object[] {
                new EntidadeLanche { Codigo= "X-Burger",
                                        Descricao = "X-Burger",
                                        Valor = Decimal.Parse("9.40") ,
                                        Ingredientes =
                                        new List<EntidadeIngrediente> { new EntidadeIngrediente { Codigo="Alface",
                                                                                                    Quantidade =1,
                                                                                                    Valor =Decimal.Parse("0.40")
                                                                                                    },
                                                                        new EntidadeIngrediente { Codigo="HambCarn",
                                                                                                    Quantidade=3,
                                                                                                    Valor =Decimal.Parse("3.00")
                                                                                                    }
                                                                        }
                        },"MuitaCarne",Decimal.Parse("6.40")
                },
            new object[] {
                new EntidadeLanche { Codigo= "X-Burger",
                                        Descricao = "X-Burger",
                                        Valor = Decimal.Parse("11.00") ,
                                        Ingredientes =
                                        new List<EntidadeIngrediente> { new EntidadeIngrediente { Codigo="Bacon",
                                                                                                    Quantidade =1,
                                                                                                    Valor =Decimal.Parse("2.00")
                                                                                                    },
                                                                        new EntidadeIngrediente { Codigo="Queijo",
                                                                                                    Quantidade=6,
                                                                                                    Valor =Decimal.Parse("1.50")
                                                                                                    }
                                                                        }
                        },"MuitoQueijo",Decimal.Parse("8.00")
                }

            };
    }
}
