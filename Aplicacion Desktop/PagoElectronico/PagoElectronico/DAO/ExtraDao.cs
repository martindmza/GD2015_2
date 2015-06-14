using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAO
{
    public class ExtraDao
    {

        public List<PaisModel> getPaises() {

            List<PaisModel> paises = new List<PaisModel>();

            PaisModel p1 = new PaisModel(1,"Argentina","Argentino");
            PaisModel p2 = new PaisModel(2, "Chile", "Chileno");
            PaisModel p3 = new PaisModel(3, "Uruguay", "Uruguayo");
            PaisModel p4 = new PaisModel(4, "Paraguay", "Paraguayo");
            PaisModel p5 = new PaisModel(5, "Perú", "Peruano");

            paises.Add(p1);
            paises.Add(p2);
            paises.Add(p3);
            paises.Add(p4);
            paises.Add(p5);

            return paises;
        }

        public PaisModel getPaisById(UInt32 id)
        {
            List<PaisModel> paises = new List<PaisModel>();

            PaisModel p1 = new PaisModel(1, "Argentina", "Argentino");
            PaisModel p2 = new PaisModel(2, "Chile", "Chileno");
            PaisModel p3 = new PaisModel(3, "Uruguay", "Uruguayo");
            PaisModel p4 = new PaisModel(4, "Paraguay", "Paraguayo");
            PaisModel p5 = new PaisModel(5, "Perú", "Peruano");

            paises.Add(p1);
            paises.Add(p2);
            paises.Add(p3);
            paises.Add(p4);
            paises.Add(p5);

            int index = (int)id;
            return paises[index];
        }

        public List<LocalidadModel> getLocalidades()
        {

            List<LocalidadModel> localidades = new List<LocalidadModel>();

           LocalidadModel l1 = new LocalidadModel(1,"Haedo");
           LocalidadModel l2 = new LocalidadModel(2,"Moron");
           LocalidadModel l3 = new LocalidadModel(3,"Liniers");
           LocalidadModel l4 = new LocalidadModel(4,"Palermo");
           LocalidadModel l5 = new LocalidadModel(5,"Belgrano");
           localidades.Add(l1);
           localidades.Add(l2);
           localidades.Add(l3);
           localidades.Add(l4);
           localidades.Add(l5);

            return localidades;
        }

        public LocalidadModel getLocalidadById(UInt32 id)
        {
            List<LocalidadModel> localidades = new List<LocalidadModel>();

            LocalidadModel l1 = new LocalidadModel(1, "Haedo");
            LocalidadModel l2 = new LocalidadModel(2, "Moron");
            LocalidadModel l3 = new LocalidadModel(3, "Liniers");
            LocalidadModel l4 = new LocalidadModel(4, "Palermo");
            LocalidadModel l5 = new LocalidadModel(5, "Belgrano");
            localidades.Add(l1);
            localidades.Add(l2);
            localidades.Add(l3);
            localidades.Add(l4);
            localidades.Add(l5);

            int value = (int)id;
            return localidades[value];
        }

        public List<DocumentoModel> getDocTypes()
        {
            List<DocumentoModel> tipos = new List<DocumentoModel>();

            DocumentoModel d1 = new DocumentoModel(1, "DNI");
            DocumentoModel d2 = new DocumentoModel(2, "Pasaporte");
            DocumentoModel d3 = new DocumentoModel(3, "Cedula");

            tipos.Add(d1);
            tipos.Add(d2);
            tipos.Add(d3);

            return tipos;
        }

        public DocumentoModel getDocTypeById(UInt32 id)
        {

            String text;

            switch (id)
            {
                case 1: text = "DNI"; break;
                case 2: text = "Pasaporte"; break;
                case 3: text = "Cedula"; break;
                default: text = "<ninguno>" ;break;
                    
            }

            return new DocumentoModel(id,text);
        }

        public DateTime getDayToday() {
            return DateTime.Today;
        }
    }
}
