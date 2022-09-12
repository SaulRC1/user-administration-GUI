using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal_Saul_Rodriguez_Naranjo.utilities
{
    /**
     * Clase que hara como modelo de datos
     * para el formulario del panel "información"
     * dentro de TabPage
     */
    public class Ciudadano
    {
        private String nombre;
        private List<String> nacionalidades;
        private int edad;
        private String estadoCivil;
        private String sexo;

        //Constantes para las nacionalidades
        public static String NACIONALIDAD_ESPANOLA = "Española";
        public static String NACIONALIDAD_PORTUGUESA = "Portuguesa";
        public static String NACIONALIDAD_ITALIANA = "Italiana";
        public static String NACIONALIDAD_FRANCESA = "Francesa";

        //Constantes para el sexo
        public static String SEXO_MASCULINO = "Hombre";
        public static String SEXO_FEMENINO = "Mujer";

        //Constantes para el estado civil
        public static String ESTADO_CIVIL_SOLTERO = "Soltero/a";
        public static String ESTADO_CIVIL_CASADO = "Casado/a";
        public static String ESTADO_CIVIL_VIUDO = "Viudo/a";

        public Ciudadano()
        {
            this.nacionalidades = new List<String>();
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getEstadoCivil()
        {
            return this.estadoCivil;
        }

        public void setEstadoCivil(String estadoCivil)
        {
            this.estadoCivil = estadoCivil;
        }

        public List<String> getNacionalidades()
        {
            return this.nacionalidades;
        }

        public void addNacionalidad(String nacionalidad)
        {
            this.nacionalidades.Add(nacionalidad);
        }

        public int getEdad()
        {
            return this.edad;
        }

        public void setEdad(int edad)
        {
            this.edad = edad;
        }
        
        public String getSexo()
        {
            return this.sexo;
        }

        public void setSexo(String sexo)
        {
            this.sexo = sexo;
        }
    }
}
