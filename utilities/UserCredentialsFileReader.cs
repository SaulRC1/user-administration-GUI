using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal_Saul_Rodriguez_Naranjo.utilities
{
    class UserCredentialsFileReader
    {
        //URL del fichero
        private String fileLocation;

        //Indica si la lectura del fichero ha fallado
        private Boolean successfulReading;

        public UserCredentialsFileReader()
        {
            //Ruta relativa a la carpeta "ficheros" dentro de nuestro proyecto
            this.fileLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\ficheros\credenciales.txt");

            //Por defecto el exito de la lectura sera falso
            this.successfulReading = false;
        }

        public UserCredentialsFileReader(String fileLocation)
        {
            this.fileLocation = fileLocation;

            //Por defecto el exito de la lectura sera falso
            this.successfulReading = false;
        }

        public List<User> getUsersFromFile()
        {
            //Usuarios que haya disponibles en el fichero
            List<User> foundUsers = new List<User>();

            if (File.Exists(this.fileLocation))
            {
                successfulReading = true;
                foundUsers = this.readUsersFromFile();
            }

            return foundUsers;
        }

        private List<User> readUsersFromFile()
        {
            //Usuarios encontrados
            List<User> usersFound = new List<User>();

            //Leemos todas las lineas del fichero
            String[] lines = File.ReadAllLines(fileLocation);

            /*
             * El formato de los usuarios es uno cada dos lineas, ya que estan
             * estructurados de la siguiente manera:
             *          
             *          USUARIO 1
             *          -----------
             *          Nombre
             *          Contraseña
             */

            //Sabiendo el formato, cada dos lineas un nombre de usuario
            for (int i = 2; i < lines.Length; i+=4)
            {
                //lines[i] --> Nombre
                //lines[i + 1] --> Contraseña
                usersFound.Add(new User(lines[i], lines[i + 1]));
            }


            return usersFound;
        }

        public Boolean isFileSuccesfullyRead()
        {
            return this.successfulReading;
        }
    }
}
