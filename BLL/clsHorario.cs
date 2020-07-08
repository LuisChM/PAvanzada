using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsHorario
    {
        public List<ConsultarHorarioResult> ConsultarHorario() 
        {
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarHorarioResult> datos = db.ConsultarHorario().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
        }
		public ConsultaHorarioResult ConsultaHorario(int IdHorario)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				ConsultaHorarioResult dato = db.ConsultaHorario(IdHorario).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool ActualizaHorario(int IdHorario, string Materia,int IdGrado,string Descripcion,DateTime Inicio,DateTime Fin,string ColorFondo,bool DiaCompleto)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.ActualizarHorario(IdHorario,Materia,IdGrado,Descripcion,Inicio,Fin,ColorFondo,DiaCompleto);
				return true;
			}
			catch (Exception ex)
			{
				return false;
				throw;
			}
		}
		public bool AgregaHorario(string Materia, int IdGrado, string Descripcion, DateTime Inicio, DateTime Fin, string ColorFondo, bool DiaCompleto)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.AgregarHorario(Materia, IdGrado, Descripcion, Inicio, Fin, ColorFondo, DiaCompleto);
				return true;
			}
			catch (Exception ex)
			{
				return false;
				throw;
			}
		}
		public bool EliminaHorario(int IdHorario)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				db.EliminarHorario(IdHorario);
				return true;
			}
			catch (Exception ex)
			{
				return false;
				throw;
			}
		}
	}
}
