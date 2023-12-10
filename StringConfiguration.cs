namespace FileGenerator
{
    public class StringConfiguration
    {
        public static string WELCOME_MESSAGE = "Welcome to File generator For CQRS Pattern : ";
        public static string MODULE_ASKING = "Please Provide The Module Name : ";
        public static string FILE_NAME_ASKING = "Please Provide The File Name : ";
        public static string OPTIONS_FOR_CREATE = "What Do you Want to Create?? Select From the Following Menu\n" +
                                                    "Enter 1 For Command\n" +
                                                    "Enter 2 for Query \n" +
                                                    "Enter 0 for exit"; 
        public static string OPTIONS_FOR_CREATE_COMMAND = "You chose to add a command.Please Specify what you want to generate.Chose from the following Menu --- \n" +
                                                    "Enter 1 For Add\n" +
                                                    "Enter 2 for Edit \n" +
                                                    "Enter 3 for Delete";
        public static string NOTHING_TO_GENERATE = "Nothing To Generate";
    }
}