using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Configuration;

namespace DAO
{
    public class ExtraDao
    {
        public DateTime getDayToday() {
            string fecha = ConfigurationSettings.AppSettings["fecha"];
            DateTime fechaDelSistema = DateTime.Parse(fecha, System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));
            return fechaDelSistema;
        }
    }
}
