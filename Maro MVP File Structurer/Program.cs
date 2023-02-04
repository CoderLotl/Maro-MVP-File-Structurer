namespace Maro_MVP_File_Structurer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opt;
            int error;

            do
            {
                // ********************************

                do
                {
                    error = 0;
                    Console.Clear();
                    Console.WriteLine("\n\n1 - Crear archivos.\n2 - Ver archivos.\n3 - Borrar archivos.\n4 - SALIR\n");
                    Console.Write("\nIngrese un numero: ");
                    if (int.TryParse(Console.ReadLine(), out opt) == false || opt > 4 || opt < 1)
                    {
                        Console.WriteLine("\nERROR - Numero fuera de rango.\nPresione una tecla...\n");
                        Console.ReadLine();
                        error = 1;
                        Console.Clear();
                    }
                } while (error == 1);

                // ********************************

                if (opt != 4)
                {
                    SubOptions(opt);
                }

            } while (opt != 4);
        }

        private static void SubOptions(int opt)
        {
            int subOpt;
            int error;

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\n\n1 - Genders.\n2 - Races.\n3 - Conditions.\n4 - Special Conditions.\n5 - Relationships.\n6 - SALIR");
                    error = 0;
                    Console.Write("\nIngrese un numero: ");
                    if (int.TryParse(Console.ReadLine(), out subOpt) == false || subOpt > 6 || subOpt < 1)
                    {
                        Console.WriteLine("\nERROR - Numero fuera de rango.\nPresione una tecla...\n");
                        Console.ReadLine();
                        error = 1;
                        Console.Clear();
                    }
                } while (error == 1);

                if (subOpt != 6)
                {
                    switch (opt)
                    {
                        case 1:
                            CreateFiles(subOpt);
                            break;
                        case 2:
                            ViewFiles(subOpt);
                            break;
                        case 3:
                            DeleteFile(subOpt);
                            break;
                    }
                }

            } while (subOpt != 6);
        }

        private static void CreateFiles(int subOpt)
        {
            List<string> variable = new List<string>();
            List<RelationshipUnit> relationships = new List<RelationshipUnit>();
            string variableName = "";
            int amount;
            int error;

            Console.Clear();

            switch (subOpt)
            {
                case 1:
                    variableName = "Genders";
                    break;
                case 2:
                    variableName = "Races";
                    break;
                case 3:
                    variableName = "Conditions";
                    break;
                case 4:
                    variableName = "Special Conditions";
                    break;
                case 5:
                    variableName = "Relationships";
                    break;
            }

            Console.WriteLine(variableName);

            do
            {
                error = 0;
                Console.Write("\nIngrese la cantidad de variables: ");
                if (int.TryParse(Console.ReadLine(), out amount) == false || amount < 1)
                {
                    Console.WriteLine("\nERROR - Numero fuera de rango.\nPresione una tecla...\n");
                    Console.ReadLine();
                    error = 1;
                    Console.Clear();
                }
            } while (error == 1);
            Console.Write("\n\n\n");

            if (subOpt != 5)
            {
                for (int i = 0; i < amount; i++)
                {
                    Console.Write("Variable {0}: ", i + 1);
                    string word = Console.ReadLine();
                    variable.Add(word);
                }
                Console.WriteLine("\nVariables:");
                foreach (var word in variable)
                {
                    Console.Write(word + " ");
                }

                JSONSerializer<List<string>> jSONSerializer = new JSONSerializer<List<string>>(variableName);
                jSONSerializer.Serialize(variable);
                Console.WriteLine("\nArchivo creado.");
                Console.Write("Presione una tecla...");
                Console.ReadLine();
            }
            else
            {
                for(int i = 0; i < amount; i++)
                {
                    RelationshipUnit newRelationship = new RelationshipUnit();
                    Console.WriteLine("Relacion {0}", i + 1);
                    Console.Write("Ingrese tipo de relacion: ");
                    newRelationship.TieName = Console.ReadLine();
                    Console.Write("Ingrese la relacion para la otra parte: ");
                    newRelationship.OppositeTie = Console.ReadLine();
                    relationships.Add(newRelationship);
                    Console.Write("\n");
                }

                foreach(RelationshipUnit relation in relationships)
                {
                    Console.WriteLine("Relacion: " + relation.TieName + " | Contraparte: " + relation.OppositeTie);
                }

                JSONSerializer<List<RelationshipUnit>> jSONSerializer = new JSONSerializer<List<RelationshipUnit>>(variableName);
                jSONSerializer.Serialize(relationships);
                Console.WriteLine("\nArchivo creado.");
                Console.Write("Presione una tecla...");
                Console.ReadLine();
            }
        }

        private static void ViewFiles(int subOpt)
        {
            List<string> variable = new List<string>();
            List<RelationshipUnit> relationships = new List<RelationshipUnit>();
            string variableName = "";

            Console.Clear();

            switch (subOpt)
            {
                case 1:
                    variableName = "Genders";
                    break;
                case 2:
                    variableName = "Races";
                    break;
                case 3:
                    variableName = "Conditions";
                    break;
                case 4:
                    variableName = "Special Conditions";
                    break;
                case 5:
                    variableName = "Relationships";
                    break;
            }

            if(subOpt != 5)
            {
                JSONSerializer<List<string>> jSONSerializer = new JSONSerializer<List<string>>(variableName);
                variable = jSONSerializer.DeSerialize();
                if(variable != null)
                {
                    foreach (string word in variable)
                    {
                        Console.Write(word + " ");
                    }
                }
                else
                {
                    Console.WriteLine("El archivo no existe.");                    
                }
                Console.Write("\nPresione una tecla...");
                Console.ReadLine();
            }
            else
            {
                JSONSerializer<List<RelationshipUnit>> jSONSerializer = new JSONSerializer<List<RelationshipUnit>>(variableName);
                relationships = jSONSerializer.DeSerialize();
                if (variable != null)
                {
                    foreach (RelationshipUnit relation in relationships)
                    {
                        Console.WriteLine("Relacion: " + relation.TieName + " | Contraparte: " + relation.OppositeTie);
                    }
                }
                else
                {
                    Console.WriteLine("El archivo no existe.");                    
                }
                Console.Write("\nPresione una tecla...");
                Console.ReadLine();
            }
        }

        private static void DeleteFile(int subOpt)
        {
            string variableName = "";
            string path = ".\\";

            Console.Clear();

            switch (subOpt)
            {
                case 1:
                    variableName = "Genders";
                    break;
                case 2:
                    variableName = "Races";
                    break;
                case 3:
                    variableName = "Conditions";
                    break;
                case 4:
                    variableName = "Special Conditions";
                    break;
                case 5:
                    variableName = "Relationships";
                    break;
            }

            if(File.Exists(path + variableName + ".json"))
            {
                File.Delete(path + variableName + ".json");
                Console.WriteLine("Archivo borrado.");
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
            Console.Write("\nPresione una tecla...");
            Console.ReadLine();
        }
    }
}
