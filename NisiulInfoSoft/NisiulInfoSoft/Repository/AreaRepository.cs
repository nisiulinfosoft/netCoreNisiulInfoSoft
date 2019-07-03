using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NisiulInfoSoft.Context;
using NisiulInfoSoft.DTO;
using System.Data.SqlClient;
using System.Data;

namespace NisiulInfoSoft.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private NisiulInfoSoftContext _contexto;

        public AreaRepository(NisiulInfoSoftContext contexto)
        {
            _contexto = contexto;
        }

        public List<AreaDTO> Listar()
        {
            return _contexto.Area.OrderBy(a => a.Descripcion).ToList();
        }

        public IQueryable ListarQueryable()
        {
            return _contexto.Area.Select(a => new { a.IdAre, a.Descripcion, a.Observacion, a.Estado })
                .OrderBy(a => a.Descripcion);
        }

        public List<AreaDTO> ListarQuery()
        {
            var query = @"SELECT 
	                        ID_ARE,
	                        DESCRIPCION,
	                        OBSERVACION,
	                        ESTADO
	                        FROM NIS_AREA
	                        ORDER BY DESCRIPCION ASC";

            return _contexto.Area.FromSql(query).ToList();
        }

        public List<AreaDTO> ListarQueryParametro(string descripcion)
        {
            var dsc = new SqlParameter("@Descripcion", descripcion);

            var query = $"SELECT ID_ARE,DESCRIPCION,OBSERVACION,ESTADO FROM NIS_AREA WHERE DESCRIPCION LIKE '%' + @Descripcion + '%' ORDER BY DESCRIPCION ASC";

            return _contexto.Area.FromSql(query, dsc).ToList();
        }

        public IQueryable ListarLinqQuery()
        {
            var query = from a in _contexto.Area
                        select new { a.IdAre, a.Descripcion, a.Observacion };

            return query;
        }

        public List<AreaDTO> ListarCommand(string descripcion)
        {
            var areas = new List<AreaDTO>();

            try
            {
                var dsc = new SqlParameter("@Descripcion", descripcion);

                var query = $"SELECT ID_ARE,DESCRIPCION,OBSERVACION,ESTADO FROM NIS_AREA WHERE DESCRIPCION LIKE '%' + @Descripcion + '%' ORDER BY DESCRIPCION ASC";

                var command = _contexto.Database.GetDbConnection().CreateCommand();

                command.CommandText = query;
                command.Parameters.Add(dsc);

                _contexto.Database.OpenConnection();

                var result = command.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        areas.Add(new AreaDTO() { IdAre = result.GetInt32(0), Descripcion = result.GetString(1), Observacion = result.GetString(2), Estado = result.GetBoolean(3) });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _contexto.Database.CloseConnection();
            }

            return areas;
        }

        public List<AreaDTO> ListarSP()
        {
            return _contexto.Area.FromSql("EXEC NISUSP_AREA_LIST").ToList();
        }

        public List<AreaDTO> ListarSPParametro(string descripcion)
        {
            var dsc = new SqlParameter("@DESCRIPCION", descripcion);

            return _contexto.Area.FromSql("EXEC NISUSP_AREA_SEARCH_DESCRIPCION @DESCRIPCION", dsc).ToList();
        }

        public List<AreaDTO> ListarSPCommand(string descripcion)
        {
            var areas = new List<AreaDTO>();

            try
            {
                var dsc = new SqlParameter("@DESCRIPCION", descripcion);

                var command = _contexto.Database.GetDbConnection().CreateCommand();

                command.CommandText = "NISUSP_AREA_SEARCH_DESCRIPCION";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(dsc);

                _contexto.Database.OpenConnection();

                var result = command.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        areas.Add(new AreaDTO() { IdAre = result.GetInt32(0), Descripcion = result.GetString(1), Observacion = result.GetString(2), Estado = result.GetBoolean(3) });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _contexto.Database.CloseConnection();
            }

            return areas;
        }

        public AreaDTO ObtenerPorId(int id)
        {
            return _contexto.Area.FirstOrDefault(a => a.IdAre == id);
        }

        public AreaDTO Insertar(AreaDTO area)
        {
            try
            {
                _contexto.Add(area);
                _contexto.SaveChanges();

                return area;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public AreaDTO InsertarExecuteSqlCommand(AreaDTO area)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@DESCRIPCION", area.Descripcion),
                    new SqlParameter("@OBSERVACION", area.Observacion),
                    new SqlParameter("@ESTADO", area.Estado)
                };

                _contexto.Database.ExecuteSqlCommand("NISUSP_AREA_INSERT @DESCRIPCION, @OBSERVACION, @ESTADO", parameters);

                return area;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public string InsertarExecuteSqlCommandOut(AreaDTO area)
        {
            var msg = "";

            try
            {
                var outRespuesta = new SqlParameter { ParameterName = "@RESPUESTA", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                        new SqlParameter("@DESCRIPCION", area.Descripcion) { SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@OBSERVACION", area.Observacion) { SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Input },
                        new SqlParameter("@ESTADO", area.Estado) { SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Input },
                        outRespuesta
                    };

                _contexto.Database.ExecuteSqlCommand("NISUSP_AREA_INSERT_OUTPUT @DESCRIPCION, @OBSERVACION, @ESTADO, @RESPUESTA OUTPUT", parameters);

                msg = outRespuesta.Value.ToString();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }

        public string InsertarCommand(AreaDTO area)
        {
            var msg = "";

            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@DESCRIPCION", area.Descripcion),
                    new SqlParameter("@OBSERVACION", area.Observacion),
                    new SqlParameter("@ESTADO", area.Estado)
                };

                var command = _contexto.Database.GetDbConnection().CreateCommand();

                command.CommandText = "NISUSP_AREA_INSERT";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                _contexto.Database.OpenConnection();

                msg = command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                _contexto.Database.CloseConnection();
            }

            return msg;
        }

        public string InsertarCommandOut(AreaDTO area)
        {
            var msg = "";

            try
            {
                var outRespuesta = new SqlParameter { ParameterName = "@RESPUESTA", SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                        new SqlParameter("@DESCRIPCION", area.Descripcion) { SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Input },
                        new SqlParameter("@OBSERVACION", area.Observacion) { SqlDbType = SqlDbType.VarChar, Size = 200, Direction = ParameterDirection.Input },
                        new SqlParameter("@ESTADO", area.Estado) { SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Input },
                        outRespuesta
                };

                var command = _contexto.Database.GetDbConnection().CreateCommand();

                command.CommandText = "NISUSP_AREA_INSERT_OUTPUT";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                _contexto.Database.OpenConnection();

                command.ExecuteNonQuery();

                msg = command.Parameters["@RESPUESTA"].Value.ToString();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                _contexto.Database.CloseConnection();
            }

            return msg;
        }

        public AreaDTO Actualizar(AreaDTO area)
        {
            try
            {
                //var areaActualizar = _contexto.Area.FirstOrDefault(a => a.Id == area.Id);

                //if (areaActualizar != null)
                //{
                //    _contexto.Update(area);
                //    _contexto.SaveChanges();

                //    return area;
                //}

                //return areaActualizar;

                _contexto.Update(area);
                _contexto.SaveChanges();

                return area;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                var area = _contexto.Area.FirstOrDefault(a => a.IdAre == id);

                if (area != null)
                {
                    _contexto.Remove(area);

                    _contexto.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
