# RAR Framework in C#

## 1. Introdução

Após ter criado o mesmo framework, originalmente em [PHP](https://github.com/aleDsz/rarframework), percebi que eu teria a mesma necessidade de um ORM em outras linguagens. Assim como eu precisei quando comecei a utilizar o C# em ambiente profissional e, com a praticidade que eu tinha em PHP, resolvi adaptar para C#.

## 2. Como Funciona

Através do pacote dbConnection, é possível realizar uma conexão com vários tipos de banco de dados. Além disso, por meio do `Generics`, é possível acessar o conteúdo de um objeto e obter todas as informações necessárias para criar uma instrução SQL.

Neste caso, uma classe deve seguir o seguinte modelo:

```csharp
using System;
using System.Data;
using RAR.Framework.Customization.Data;

namespace Test.Entities
{
    [DbTable("nome_da_tabela")]
    public class Teste
    {
        [DbColumn("nome_do_campo", DbType.Int32, IsPK = true)]
        public Int32 Campo { get; set; }

        [DbColumn("nome_do_campo2", DbType.StringFixedLength, Size = 30)]
        public String Campo2 { get; set; }
    }
}
```

## 3. Como Utilizar

Para que você possa utilizar todos as funcionalidades do framework no seu ambiente, você pode criar 1 (ou mais, dependendo da sua forma de trabalho) classe para acessar ao banco de dados de forma genérica.

```csharp
using System;
using System.Collections.Generic;
using RAR.Framework.Database.Command;
using RAR.Framework.Database.Data;
using RAR.Framework.Database.Enums;
using RAR.Framework.Database.Objects;
using RAR.Framework.Database.SQL;

namespace Test.DataAccess
{
    public class ModelDataAccess<T>
    {
        public ModelDataAccess()
        {
        }

        public void Create(T obj, Boolean isTransactioned)
        {
            try
            {
                var context = DatabaseFactory.DataContext();
                var ssql = new SQLStatementInsert<T>(obj);

                context.Begin();

                using (var cmd = new CommandContext(ssql.GetSQL(), context))
                {
                    cmd.ExecuteQuery();

                    context.Commit();
                }

                 Factory<T>.DestroyInstance<T>(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(T obj)
        {
            try
            {
                var context = DatabaseFactory.DataContext();
                var ssql = new SQLStatementUpdate<T>(obj);

                context.Begin();

                using (var cmd = new CommandContext(ssql.GetSQL(), context))
                {
                    cmd.ExecuteQuery();

                    context.Commit();
                }

                Factory<T>.DestroyInstance<T>(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(T obj)
        {
            try
            {
                var context = DatabaseFactory.DataContext();
                var ssql = new SQLStatementDelete<T>(obj);

                context.Begin(System.Data.IsolationLevel.ReadUncommitted);

                using (var cmd = new CommandContext(ssql.GetSQL(), context))
                {
                    cmd.ExecuteQuery();

                    context.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Object Find(T obj)
        {
            Object objRetorno;
            try
            {
                var context = DatabaseFactory.DataContext();
                var ssql = new SQLStatementSelect<Object>(obj);

                context.Begin(System.Data.IsolationLevel.ReadUncommitted);

                using (var cmd = new CommandContext(ssql.GetSQL(TiposSelect.ByKey), context))
                {
                    var ObjectContext = new ObjectContext<Object>(obj);
                    objRetorno = ObjectContext.GetObject<Object>(cmd.ExecuteReader());

                    context.Commit();
                }

                return objRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Object> FindAll(Object obj)
        {
            List<Object> retorno = null;

            if (obj == null)
                obj = new Object();

            try
            {
                var context = DatabaseFactory.DataContext();
                var ssql = new SQLStatementSelect<Object>(obj);

                context.Begin(System.Data.IsolationLevel.ReadUncommitted);

                using (var cmd = new CommandContext(ssql.GetSQL(TiposSelect.All), context))
                {
                    var ObjectContext = new ObjectContext<Object>(obj);
                    retorno = ObjectContext.GetObjects<Object>(cmd.ExecuteReader());

                    context.Commit();
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
```

**OBS.:** Você não precisa criar a classe de forma genérica, você pode criar uma classe de acesso a dados para cada entidade que você criar no modelo citado acima.

## 4. Como Contribuir

Para contribuir, você pode realizar um **fork** do nosso repositório e nos enviar um Pull Request.

## 5. Doação

Caso queria fazer uma doação para o projeto, você pode realizar [aqui](https://twitch.streamlabs.com/aleDsz)

## 6. Suporte

Caso você tenha algum problema ou uma sugestão, você pode nos contatar [aqui](https://github.com/aleDsz/rarframework-net/issues).

## 7. Licença

Cheque [aqui](LICENSE)
