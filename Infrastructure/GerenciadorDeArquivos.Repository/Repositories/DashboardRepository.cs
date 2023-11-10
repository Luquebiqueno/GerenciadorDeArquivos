using Dapper;
using GerenciadorDeArquivos.Common.Domain.Interfaces;
using GerenciadorDeArquivos.Common.Infrastructure.Repository;
using GerenciadorDeArquivos.Domain.Dto;
using GerenciadorDeArquivos.Domain.Entities;
using GerenciadorDeArquivos.Domain.Interfaces.Repository;
using GerenciadorDeArquivos.Repository.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeArquivos.Repository.Repositories
{
    public class DashboardRepository<TContext> : RepositoryBase<TContext, Arquivo, int>, IDashboardRepository<TContext>
                                where TContext : IUnitOfWork<TContext>
    {
        private DbSession _dbSession;
        public DashboardRepository(IUnitOfWork<TContext> unitOfWork,
                                   DbSession dbSession) : base(unitOfWork)
        {
            _dbSession = dbSession;
        }

        public async Task<IEnumerable<DashboardDto>> GetDashboard(int usuarioId, DateTime dataInicial, DateTime dataFinal)
        {
            using (var conn = _dbSession.Connection)
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@UsuarioId", usuarioId, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@DataInicial", dataInicial, DbType.Date, ParameterDirection.Input);
                parameter.Add("@DataFinal", dataFinal, DbType.Date, ParameterDirection.Input);

                string query = "GetDashboard";

                return await (conn.QueryAsync<DashboardDto>(sql: query, param: parameter, commandType: CommandType.StoredProcedure));
            }
        }
    }
}
