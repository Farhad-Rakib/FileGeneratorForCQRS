using System;
using System.Configuration;
using System.IO;

namespace FileGenerator
{
    public class Program
    {
        static readonly string CommandFolderLocation = ConfigurationManager.AppSettings["CommnadFolderLocation"];
        static readonly string QueryFolderLocation = ConfigurationManager.AppSettings["QueryFolderLocation"];
        static readonly string InferfaceFolderLocation = ConfigurationManager.AppSettings["InferfaceFolderLocation"];
        static readonly string ServiceImplementationFolderLocation = ConfigurationManager.AppSettings["ServiceImplementationFolderLocation"];
        static readonly string RepoImplementationFolderLocation = ConfigurationManager.AppSettings["RepoImplementationFolderLocation"];
        static readonly string DtoFolderLocation = ConfigurationManager.AppSettings["DtoFolderLocation"];
        static readonly string EntityFolderLocation = ConfigurationManager.AppSettings["EntityFolderLocation"];
        static readonly string ControllerFolderLocation = ConfigurationManager.AppSettings["ControllerFolderLocation"];

        static void Main(string[] args)
        {
            Console.WriteLine(StringConfiguration.WELCOME_MESSAGE);
            Console.WriteLine(StringConfiguration.MODULE_ASKING);
            string nameOfTheModule = Console.ReadLine();
            Console.WriteLine(StringConfiguration.FILE_NAME_ASKING);
            string nameOfTheFile = Console.ReadLine();
            Console.WriteLine(StringConfiguration.OPTIONS_FOR_CREATE);
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 0)
            {
                Console.WriteLine(StringConfiguration.NOTHING_TO_GENERATE);
                Environment.Exit(0);
            }
            if (choice == 1)
            {
                var result = GenerateCommands(nameOfTheModule, nameOfTheFile, CommandFolderLocation);
            }
            else if (choice == 2)
            {

                var result = GenerateQueries(nameOfTheModule, nameOfTheFile, QueryFolderLocation);

            }


        }
        public static bool GenerateCommands(string moduleName, string fileName, string folderLocation)
        {
            bool isCreated = false;
            Console.WriteLine(StringConfiguration.OPTIONS_FOR_CREATE_COMMAND);
            int subchoice = Convert.ToInt32(Console.ReadLine());
            var moduleFolderLocation = folderLocation + "\\" + moduleName;
            
            if (!Directory.Exists(moduleFolderLocation)) Directory.CreateDirectory(moduleFolderLocation);
            if (Directory.Exists(moduleFolderLocation))
            {

                if (subchoice == 1)
                {
                    var addCommandFolder = moduleFolderLocation + "\\" + "Add" + fileName;
                    if (!Directory.Exists(addCommandFolder)) Directory.CreateDirectory(addCommandFolder);
                    if (Directory.Exists(addCommandFolder))
                    {
                        string content = "" +
                            "public class Add" + fileName + "Command : " + fileName + "Dto , IRequest<IActionResult>\n" +
                                         "{\n" +
                                         "}\n";
                        string filepath = addCommandFolder + "\\" + "Add" + fileName + "Command.cs";
                        if (!File.Exists(filepath)) File.WriteAllText(filepath, content);

                        string addFileName = "Add" + fileName + "Command";

                        string handlerContent = "" +
                            $"public class Add" + fileName + "CommandHandler :  IRequestHandler < {addFileName} ,IActionResult>\n" +
                                         "{\n" +
                                         "}\n ";
                        string hanlderFilepath = addCommandFolder + "\\" + "Add" + fileName + "CommandHandler.cs";
                        if (!File.Exists(hanlderFilepath)) File.WriteAllText(hanlderFilepath, handlerContent);


                        isCreated = true;
                    }

                    GenerateEntity(moduleName, fileName, EntityFolderLocation);
                    GenerateDto(moduleName, fileName, DtoFolderLocation);
                    isCreated = true;

                }
                else if (subchoice == 2)
                {
                    var editCommandFolder = moduleFolderLocation + "\\" + "Edit" + fileName;
                    if (!Directory.Exists(editCommandFolder)) Directory.CreateDirectory(editCommandFolder);
                    if (Directory.Exists(editCommandFolder))
                    {
                        string content = "" +
                            "public class Edit" + fileName + "Command : " + fileName + "Dto , IRequest<IActionResult>\n" +
                                         "{\n" +
                                         "}\n";
                        string filepath = editCommandFolder + "\\" + "Edit" + fileName + "Command.cs";
                        if (!File.Exists(filepath)) File.WriteAllText(filepath, content);

                        string editFileName = "Edit" + fileName + "Command";

                        string handlerContent = "" +
                            $"public class Edit" + fileName + "CommandHandler :  IRequestHandler < {editFileName} ,IActionResult>\n" +
                                         "{\n" +
                                         "}\n ";
                        string hanlderFilepath = editCommandFolder + "\\" + "Edit" + fileName + "CommandHandler.cs";

                        if (!File.Exists(hanlderFilepath)) File.WriteAllText(hanlderFilepath, handlerContent);
                        isCreated = true;

                    }

                }
                else if (subchoice == 3)
                {
                    var deletedCommandFolder = moduleFolderLocation + "\\" + "Delete" + fileName;
                    if (!Directory.Exists(deletedCommandFolder)) Directory.CreateDirectory(deletedCommandFolder);
                    if (Directory.Exists(deletedCommandFolder))
                    {
                        string content = "" +
                            "public class Delete" + fileName + "Command : " + fileName + "Dto , IRequest<IActionResult>\n" +
                                         "{\n" +
                                         "}\n";
                        string filepath = deletedCommandFolder + "\\" + "Delete" + fileName + "Command.cs";
                        if (!File.Exists(filepath)) if (!File.Exists(filepath)) File.WriteAllText(filepath, content);

                        string deleteFileName = "Delete" + fileName + "Command";

                        string handlerContent = "" +
                            $"public class Delete" + fileName + "CommandHandler :  IRequestHandler < {deleteFileName} ,IActionResult>\n" +
                                         "{\n" +
                                         "}\n ";
                        string hanlderFilepath = deletedCommandFolder + "\\" + "Delete" + fileName + "CommandHandler.cs";
                        if (!File.Exists(hanlderFilepath)) if (!File.Exists(hanlderFilepath)) File.WriteAllText(hanlderFilepath, handlerContent);

                        isCreated = true;

                    }
                }
                else 
                {
                    Console.WriteLine(StringConfiguration.NOTHING_TO_GENERATE);
                    Environment.Exit(0);
                }

                GenerateInterfaces(moduleName,fileName, InferfaceFolderLocation);
                GenerateInterFacesImplementation(moduleName,fileName, ServiceImplementationFolderLocation, RepoImplementationFolderLocation);
                GenerateController(moduleName,fileName, ControllerFolderLocation);

            }

            return isCreated;
        }
        private static bool GenerateQueries(string moduleName, string fileName, string folderLocation)
        {
            bool isCreated = false;
            var moduleFolderLocation = folderLocation + "\\" + moduleName;
            if (!Directory.Exists(moduleFolderLocation)) Directory.CreateDirectory(moduleFolderLocation);
            if (Directory.Exists(moduleFolderLocation))
            {

                var getQueriesFolder = moduleFolderLocation + "\\" + "Get" + fileName;
                if (!Directory.Exists(getQueriesFolder)) Directory.CreateDirectory(getQueriesFolder);
                if (Directory.Exists(getQueriesFolder))
                {
                    string content = "" +
                        "public class Get" + fileName + "Query : " + fileName + "Dto , IRequest<IActionResult>\n" +
                                     "{\n" +
                                     "}\n";
                    string filepath = getQueriesFolder + "\\" + "Get" + fileName + "Query.cs";
                    if (!File.Exists(filepath)) File.WriteAllText(filepath, content);


                    string getCmmndFileName = "Get" + fileName + "Query";

                    string handlerContent = "" +
                        "public class Get" + fileName + "QueryHandler :  IRequestHandler < {0} ,IActionResult>\n" +
                                     "{\n" +
                                     "}\n ";
                    string hanlderFilepath = getQueriesFolder + "\\" + "Add" + fileName + "CommandHandler.cs";
                    if (!File.Exists(hanlderFilepath)) File.WriteAllText(hanlderFilepath, handlerContent);

                    isCreated = true;
                }
                GenerateEntity(moduleName,fileName, InferfaceFolderLocation);
                GenerateDto(moduleName,fileName, InferfaceFolderLocation);
                GenerateInterfaces(moduleName, fileName, InferfaceFolderLocation);
                GenerateInterFacesImplementation(moduleName, fileName, ServiceImplementationFolderLocation, RepoImplementationFolderLocation);
                GenerateController(moduleName, fileName, ControllerFolderLocation);

            }
            return isCreated;
        }
        private static bool GenerateInterfaces(string moduleName, string FileName, string InterfaceFolderLocation)
        {

            var moduleFolderLocation = InterfaceFolderLocation + "\\" + moduleName;
            if (!Directory.Exists(moduleFolderLocation)) Directory.CreateDirectory(moduleFolderLocation);
            if (Directory.Exists(moduleFolderLocation))
            {

                    var InterFaceFolderLocation = moduleFolderLocation + "\\" + FileName;
                    if (!Directory.Exists(InterFaceFolderLocation)) Directory.CreateDirectory(InterFaceFolderLocation);
                    var reposInterface = InterFaceFolderLocation + "\\" + "RepositoryInterfaces";
                    if (!Directory.Exists(reposInterface)) Directory.CreateDirectory(reposInterface);
                    var srvcInterface = InterFaceFolderLocation + "\\" + "ServiceInterfaces";
                    if (!Directory.Exists(srvcInterface)) Directory.CreateDirectory(srvcInterface);


                    if (Directory.Exists(reposInterface))
                    {
                        string content = "" +
                            "public interface I" + FileName + "Repository  \n" +
                                         "{\n" +
                                         "}\n";
                        string filepath = reposInterface + "\\" + "I" + FileName + "Repository.cs";
                        if (!File.Exists(filepath)) File.WriteAllText(filepath, content);

                    }
                    if (Directory.Exists(srvcInterface))
                    {
                        string content = "" +
                            "public interface I" + FileName + "Service  \n" +
                                         "{\n" +
                                         "}\n";
                        string filepath = srvcInterface + "\\" + "I" + FileName + "Service.cs";
                        if (!File.Exists(filepath)) File.WriteAllText(filepath, content);
                    }
                    return true;
                
            }

            return false;
        }
        private static bool GenerateInterFacesImplementation(string moduleName, string FileName, string ServiceImplementationFolderLocation, string RepoImplementationFolderLocation)
        {
            var srvcsModuleFolderLocation = ServiceImplementationFolderLocation + "\\" + moduleName;
            if (!Directory.Exists(srvcsModuleFolderLocation)) Directory.CreateDirectory(srvcsModuleFolderLocation);
            var repoModuleFolderLocation = RepoImplementationFolderLocation + "\\" + moduleName;
            if (!Directory.Exists(repoModuleFolderLocation)) Directory.CreateDirectory(repoModuleFolderLocation);
            bool isCreated = false;

            if (Directory.Exists(srvcsModuleFolderLocation) && Directory.Exists(repoModuleFolderLocation))
            {

                var srvcInetrfaceImpFolderLocation = srvcsModuleFolderLocation + "\\" + FileName;
                if (!Directory.Exists(srvcInetrfaceImpFolderLocation)) Directory.CreateDirectory(srvcInetrfaceImpFolderLocation);
                var repoInterfaceImpFolderLocation = repoModuleFolderLocation + "\\" + FileName;
                if (!Directory.Exists(repoInterfaceImpFolderLocation)) Directory.CreateDirectory(repoInterfaceImpFolderLocation);

                if (Directory.Exists(srvcInetrfaceImpFolderLocation))
                {
                    string content = "" +
                        "public class " + FileName + "Service  \n" +
                                     "{\n" +
                                     "}\n";
                    string filepath = srvcInetrfaceImpFolderLocation + "\\" + "" + FileName + "Service.cs";
                    if (!File.Exists(filepath)) File.WriteAllText(filepath, content);
                    isCreated = true;

                }

                if (Directory.Exists(repoInterfaceImpFolderLocation))
                {
                    string content = "" +
                        "public class " + FileName + "Repository  \n" +
                                     "{\n" +
                                     "}\n";
                    string filepath = repoInterfaceImpFolderLocation + "\\" + FileName + "Repository.cs";
                    if (!File.Exists(filepath)) File.WriteAllText(filepath, content);
                    isCreated = true;
                }
            }

            return isCreated;


        }
        private static bool GenerateDto(string moduleName, string FileName, string dtoFolderLocation)
        {
            var moduleFolderLocation = dtoFolderLocation + "\\" + moduleName;
            if (!Directory.Exists(moduleFolderLocation)) Directory.CreateDirectory(moduleFolderLocation);
            bool isCreated = false;

            if (Directory.Exists(moduleFolderLocation))

            {
                var dtoLocation = moduleFolderLocation + "\\" + FileName;
                if (!Directory.Exists(dtoLocation)) Directory.CreateDirectory(dtoLocation);
                if (Directory.Exists(dtoLocation))
                {
                    string content = "" +
                        "public class " + FileName + "Dto  \n" +
                                     "{\n" +
                                     "}\n";
                    string filepath = dtoLocation + "\\" + "" + FileName + "Dto.cs";
                    if (!File.Exists(filepath)) File.WriteAllText(filepath, content);
                    isCreated = true;

                }
            }


            return isCreated;
        }
        private static bool GenerateEntity(string moduleName, string FileName, string entityFolderLocation)
        {
            var moduleFolderLocation = entityFolderLocation + "\\" + moduleName;
            if (!Directory.Exists(moduleFolderLocation)) Directory.CreateDirectory(moduleFolderLocation);
            bool isCreated = false;

            if (Directory.Exists(moduleFolderLocation))
            {
                var entyLocation = moduleFolderLocation + "\\" + FileName;
                if (!Directory.Exists(entyLocation)) Directory.CreateDirectory(entyLocation);
                if (Directory.Exists(entyLocation))
                {
                    string content = "" +
                        "public class " + FileName + "\n" +
                                     "{\n" +
                                     "}\n";
                    string filepath = entyLocation + "\\" + "" + FileName + ".cs";
                    if (!File.Exists(filepath)) File.WriteAllText(filepath, content);
                    isCreated = true;

                }
            }


            return isCreated;
        }
        private static bool GenerateController(string moduleName,string FileName, string controllerFolderLocation)
        {


            var moduleFolderLocation = controllerFolderLocation + "\\" + moduleName;
            if (!Directory.Exists(moduleFolderLocation)) Directory.CreateDirectory(moduleFolderLocation);
            bool isCreated = false;

            if (Directory.Exists(moduleFolderLocation)) 
            {
                var entyLocation = moduleFolderLocation + "\\" + FileName;
                if (!Directory.Exists(entyLocation)) Directory.CreateDirectory(entyLocation);
                if (Directory.Exists(entyLocation))
                {
                    string content = "" +
                        "[CustomAuthorization]\n" +
                        "public class " + FileName + "Controller : BaseApiController \n " +
                                     "{\n" +
                                     "}\n";
                    string filepath = entyLocation + "\\" + "" + FileName + "Controller.cs";
                    if (!File.Exists(filepath)) File.WriteAllText(filepath, content);
                    isCreated = true;

                }
            }

            return isCreated;
        }
    }
}
