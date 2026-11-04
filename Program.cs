using System;

void ShowMainMenu()
{
    Console.WriteLine("--------- MENU PRINCIPAL ---------");
    Console.WriteLine("1. Libros");
    Console.WriteLine("2. Usuarios");
    Console.WriteLine("3. Préstamos");
    Console.WriteLine("4. Búsquedas y reportes");
    Console.WriteLine("5. Guardar / Cargar datos");
    Console.WriteLine("6. Salir");
}

void ShowBooksMenu()
{
    Console.WriteLine("--------- MENU LIBROS ---------");
    Console.WriteLine("1.1 Registrar libro");
    Console.WriteLine("1.2 Listar libros");
    Console.WriteLine("    • 1.2.1 Listar todos");
    Console.WriteLine("    • 1.2.2 Listar disponibles");
    Console.WriteLine("    • 1.2.3 Listar prestados");
    Console.WriteLine("1.3 Ver detalle (por ID/ISBN)");
    Console.WriteLine("1.4 Actualizar libro");
    Console.WriteLine("    • 1.4.1 Editar título");
    Console.WriteLine("    • 1.4.2 Editar autor");
    Console.WriteLine("    • 1.4.3 Editar año / categoría");
    Console.WriteLine("1.5 Eliminar libro");
    Console.WriteLine("0. Volver");
    Console.WriteLine("9. Salir");
}

void ShowUsersMenu()
{
    Console.WriteLine("--------- MENU USUARIOS ---------");
    Console.WriteLine("2.1 Registrar usuario");
    Console.WriteLine("2.2 Listar usuarios");
    Console.WriteLine("2.3 Ver detalle (por ID/documento)");
    Console.WriteLine("2.4 Actualizar usuario (nombre, contacto y estado)");
    Console.WriteLine("    • 2.4.1 Editar nombre");
    Console.WriteLine("    • 2.4.2 Editar contacto");
    Console.WriteLine("    • 2.4.3 Activar / desactivar");
    Console.WriteLine("2.5 Eliminar usuario");
    Console.WriteLine("0. Volver");
    Console.WriteLine("9. Salir");
}

void ShowLoansMenu()
{
    Console.WriteLine("--------- MENU PRÉSTAMOS ---------");
    Console.WriteLine("3.1 Crear préstamo");
    Console.WriteLine("3.2 Listar préstamos");
    Console.WriteLine("    • 3.2.1 Todos");
    Console.WriteLine("    • 3.2.2 Activos");
    Console.WriteLine("    • 3.2.3 Cerrados");
    Console.WriteLine("3.3 Ver detalle de préstamo");
    Console.WriteLine("3.4 Registrar devolución");
    Console.WriteLine("3.5 Eliminar préstamo");
    Console.WriteLine("0. Volver");
    Console.WriteLine("9. Salir");
}

void ShowSearchReportsMenu()
{
    Console.WriteLine("--------- BÚSQUEDAS Y REPORTES ---------");
    Console.WriteLine("4.1 Buscar libro");
    Console.WriteLine("4.2 Buscar usuario");
    Console.WriteLine("4.3 Reportes");
    Console.WriteLine("    • 4.3.1 Por usuario");
    Console.WriteLine("    • 4.3.2 Por libro");
    Console.WriteLine("    • 4.3.3 Vencidos");
    Console.WriteLine("    • 4.3.4 Resumen");
    Console.WriteLine("0. Volver");
    Console.WriteLine("9. Salir");
}

void ShowPersistenceMenu()
{
    Console.WriteLine("--------- GUARDAR / CARGAR DATOS ---------");
    Console.WriteLine("5.1 Guardar datos");
    Console.WriteLine("5.2 Cargar datos");
    Console.WriteLine("5.3 Reiniciar datos");
    Console.WriteLine("0. Volver");
    Console.WriteLine("9. Salir");
}

string ReadText(string message)
{
    Console.Write(message);
    return Console.ReadLine() ?? string.Empty;
}

bool ConfirmAction(string actionMessage)
{
    string answer = ReadText($"{actionMessage} (S/N): ").Trim();
    return answer.Equals("S", StringComparison.OrdinalIgnoreCase);
}

bool ConfirmResetData()
{
    return ConfirmAction("¿Desea reiniciar los datos?");
}

bool ConfirmExitAndSave()
{
    return ConfirmAction("¿Guardar antes de salir?");
}

void RegisterBook()
{
    Console.WriteLine("Registrar libro: se validan los datos mínimos sugeridos.");
    string titulo = ReadText("Ingresa el título del libro: ");
    string autor = ReadText("Ingresa el nombre del autor: ");
    string categoria = ReadText("Ingresa la categoría: ");
    string anio = ReadText("Ingresa el año de publicación: ");
    Console.WriteLine($"Libro registrado: '{titulo}' - {autor} - {categoria} - {anio}.");
}

void ListBooksMenu()
{
    while (true)
    {
        Console.WriteLine("--------- LISTAR LIBROS ---------");
        Console.WriteLine("1.2.1 Listar todos");
        Console.WriteLine("1.2.2 Listar disponibles");
        Console.WriteLine("1.2.3 Listar prestados");
        Console.WriteLine("0. Volver");

        string opcion = ReadText("Elige una opción: ").Trim();

        switch (opcion)
        {
            case "1.2.1":
                ListBooksAll();
                break;
            case "1.2.2":
                ListBooksAvailable();
                break;
            case "1.2.3":
                ListBooksBorrowed();
                break;
            case "0":
                Console.WriteLine("Volviendo al menú de libros...");
                return;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    }
}

void ListBooksAll()
{
    Console.WriteLine("Listando todos los libros: simulación de catálogo completo.");
}

void ListBooksAvailable()
{
    Console.WriteLine("Listando libros disponibles: solo los que no tienen préstamo activo.");
}

void ListBooksBorrowed()
{
    Console.WriteLine("Listando libros prestados: solo los títulos con préstamos activos.");
}

void ViewBookDetail()
{
    Console.WriteLine("Ver detalle del libro: buscar por ID o ISBN y mostrar información del ejemplar.");
}

void UpdateBookMenu()
{
    while (true)
    {
        Console.WriteLine("--------- ACTUALIZAR LIBRO ---------");
        Console.WriteLine("1.4.1 Editar título");
        Console.WriteLine("1.4.2 Editar autor");
        Console.WriteLine("1.4.3 Editar año / categoría");
        Console.WriteLine("0. Volver");

        string opcion = ReadText("Elige una opción: ").Trim();

        switch (opcion)
        {
            case "1.4.1":
                EditBookTitle();
                break;
            case "1.4.2":
                EditBookAuthor();
                break;
            case "1.4.3":
                EditBookYearCategory();
                break;
            case "0":
                Console.WriteLine("Volviendo al menú de libros...");
                return;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    }
}

void EditBookTitle()
{
    Console.WriteLine("Editar título del libro: se actualiza el campo título del registro seleccionado.");
}

void EditBookAuthor()
{
    Console.WriteLine("Editar autor del libro: se actualiza el campo autor del registro seleccionado.");
}

void EditBookYearCategory()
{
    Console.WriteLine("Editar año o categoría del libro: se actualizan los datos del registro seleccionado.");
}

void DeleteBook()
{
    Console.WriteLine("Eliminar libro: validar que el libro no esté prestado antes de eliminarlo.");
}

void RegisterUser()
{
    Console.WriteLine("Registrar usuario: se validan datos mínimos del usuario (id, nombre, contacto, estado). ");
    string nombre = ReadText("Ingresa el nombre del usuario: ");
    string contacto = ReadText("Ingresa el contacto: ");
    Console.WriteLine($"Usuario registrado: '{nombre}' - {contacto}.");
}

void ListUsers()
{
    Console.WriteLine("Listando usuarios: simulación de listado completo de usuarios activos e inactivos.");
}

void ViewUserDetail()
{
    Console.WriteLine("Ver detalle del usuario: buscar por ID o documento para mostrar su información.");
}

void UpdateUserMenu()
{
    while (true)
    {
        Console.WriteLine("--------- ACTUALIZAR USUARIO ---------");
        Console.WriteLine("2.4.1 Editar nombre");
        Console.WriteLine("2.4.2 Editar contacto");
        Console.WriteLine("2.4.3 Activar / desactivar");
        Console.WriteLine("0. Volver");

        string opcion = ReadText("Elige una opción: ").Trim();

        switch (opcion)
        {
            case "2.4.1":
                EditUserName();
                break;
            case "2.4.2":
                EditUserContact();
                break;
            case "2.4.3":
                ToggleUserActiveStatus();
                break;
            case "0":
                Console.WriteLine("Volviendo al menú de usuarios...");
                return;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    }
}

void EditUserName()
{
    Console.WriteLine("Editar nombre del usuario: actualizar el nombre registrado.");
}

void EditUserContact()
{
    Console.WriteLine("Editar contacto del usuario: actualizar el teléfono, correo u otra información de contacto.");
}

void ToggleUserActiveStatus()
{
    Console.WriteLine("Activar / desactivar usuario: cambiar el estado del usuario en el sistema.");
}

void DeleteUser()
{
    Console.WriteLine("Eliminar usuario: validar que el usuario no tenga préstamos activos antes de eliminarlo.");
}

void CreateLoan()
{
    Console.WriteLine("Crear préstamo: validar disponibilidad del libro, usuario activo, fechas y reglas del sistema.");
}

void ListLoansMenu()
{
    while (true)
    {
        Console.WriteLine("--------- LISTAR PRÉSTAMOS ---------");
        Console.WriteLine("3.2.1 Todos");
        Console.WriteLine("3.2.2 Activos");
        Console.WriteLine("3.2.3 Cerrados");
        Console.WriteLine("0. Volver");

        string opcion = ReadText("Elige una opción: ").Trim();

        switch (opcion)
        {
            case "3.2.1":
                ListLoansAll();
                break;
            case "3.2.2":
                ListLoansActive();
                break;
            case "3.2.3":
                ListLoansClosed();
                break;
            case "0":
                Console.WriteLine("Volviendo al menú de préstamos...");
                return;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    }
}

void ListLoansAll()
{
    Console.WriteLine("Listando todos los préstamos: simulación de historial general.");
}

void ListLoansActive()
{
    Console.WriteLine("Listando préstamos activos: solo registros en curso.");
}

void ListLoansClosed()
{
    Console.WriteLine("Listando préstamos cerrados: solo registros devueltos o finalizados.");
}

void ViewLoanDetail()
{
    Console.WriteLine("Ver detalle del préstamo: buscar por ID para mostrar información del préstamo.");
}

void RegisterReturn()
{
    Console.WriteLine("Registrar devolución: marcar el préstamo como devuelto y dejar el libro disponible.");
}

void DeleteLoan()
{
    Console.WriteLine("Eliminar préstamo: aplicar reglas sugeridas antes de borrarlo del sistema.");
}

void SearchBook()
{
    Console.WriteLine("Buscar libro: filtrar por título, autor, ID o categoría.");
}

void SearchUser()
{
    Console.WriteLine("Buscar usuario: filtrar por nombre o documento.");
}

void ReportsMenu()
{
    while (true)
    {
        Console.WriteLine("--------- REPORTES ---------");
        Console.WriteLine("4.3.1 Por usuario");
        Console.WriteLine("4.3.2 Por libro");
        Console.WriteLine("4.3.3 Vencidos");
        Console.WriteLine("4.3.4 Resumen");
        Console.WriteLine("0. Volver");

        string opcion = ReadText("Elige una opción: ").Trim();

        switch (opcion)
        {
            case "4.3.1":
                ReportByUser();
                break;
            case "4.3.2":
                ReportByBook();
                break;
            case "4.3.3":
                ReportOverdue();
                break;
            case "4.3.4":
                ReportSummary();
                break;
            case "0":
                Console.WriteLine("Volviendo al menú de búsquedas y reportes...");
                return;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    }
}

void ReportByUser()
{
    Console.WriteLine("Reporte por usuario: mostrar préstamos, historial y estado por cada usuario.");
}

void ReportByBook()
{
    Console.WriteLine("Reporte por libro: mostrar disponibilidad, préstamos y estadísticas del ejemplar.");
}

void ReportOverdue()
{
    Console.WriteLine("Reporte de vencidos: listar préstamos vencidos por usuario o libro.");
}

void ReportSummary()
{
    Console.WriteLine("Resumen general: presentar indicadores clave del sistema.");
}

void SaveData()
{
    Console.WriteLine("Guardar datos: simulación de guardado de información del sistema.");
}

void LoadData()
{
    Console.WriteLine("Cargar datos: simulación de carga de información previamente guardada.");
}

void ResetData()
{
    Console.WriteLine("Reiniciar datos: limpiar registros simulados y comenzar una nueva sesión.");
}

void ManageBooksMenu()
{
    while (true)
    {
        ShowBooksMenu();
        string opcion = ReadText("Elije una opción del menú de libros: ").Trim();

        switch (opcion)
        {
            case "1.1":
                RegisterBook();
                break;
            case "1.2":
                ListBooksMenu();
                break;
            case "1.3":
                ViewBookDetail();
                break;
            case "1.4":
                UpdateBookMenu();
                break;
            case "1.5":
                DeleteBook();
                break;
            case "0":
                Console.WriteLine("Volviendo al menú principal...");
                return;
            case "9":
                if (ConfirmExitAndSave())
                {
                    SaveData();
                }
                Console.WriteLine("Gracias por usar la biblioteca.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    }
}

void ManageUsersMenu()
{
    while (true)
    {
        ShowUsersMenu();
        string opcion = ReadText("Elije una opción del menú de usuarios: ").Trim();

        switch (opcion)
        {
            case "2.1":
                RegisterUser();
                break;
            case "2.2":
                ListUsers();
                break;
            case "2.3":
                ViewUserDetail();
                break;
            case "2.4":
                UpdateUserMenu();
                break;
            case "2.5":
                DeleteUser();
                break;
            case "0":
                Console.WriteLine("Volviendo al menú principal...");
                return;
            case "9":
                if (ConfirmExitAndSave())
                {
                    SaveData();
                }
                Console.WriteLine("Gracias por usar la biblioteca.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    }
}

void ManageLoansMenu()
{
    while (true)
    {
        ShowLoansMenu();
        string opcion = ReadText("Elije una opción del menú de préstamos: ").Trim();

        switch (opcion)
        {
            case "3.1":
                CreateLoan();
                break;
            case "3.2":
                ListLoansMenu();
                break;
            case "3.3":
                ViewLoanDetail();
                break;
            case "3.4":
                RegisterReturn();
                break;
            case "3.5":
                DeleteLoan();
                break;
            case "0":
                Console.WriteLine("Volviendo al menú principal...");
                return;
            case "9":
                if (ConfirmExitAndSave())
                {
                    SaveData();
                }
                Console.WriteLine("Gracias por usar la biblioteca.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    }
}

void ManageSearchReportsMenu()
{
    while (true)
    {
        ShowSearchReportsMenu();
        string opcion = ReadText("Elije una opción del menú de búsquedas y reportes: ").Trim();

        switch (opcion)
        {
            case "4.1":
                SearchBook();
                break;
            case "4.2":
                SearchUser();
                break;
            case "4.3":
                ReportsMenu();
                break;
            case "0":
                Console.WriteLine("Volviendo al menú principal...");
                return;
            case "9":
                if (ConfirmExitAndSave())
                {
                    SaveData();
                }
                Console.WriteLine("Gracias por usar la biblioteca.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    }
}

void ManagePersistenceMenu()
{
    while (true)
    {
        ShowPersistenceMenu();
        string opcion = ReadText("Elije una opción del menú de persistencia: ").Trim();

        switch (opcion)
        {
            case "5.1":
                SaveData();
                break;
            case "5.2":
                LoadData();
                break;
            case "5.3":
                if (ConfirmResetData())
                {
                    ResetData();
                }
                else
                {
                    Console.WriteLine("Se canceló el reinicio de datos.");
                }
                break;
            case "0":
                Console.WriteLine("Volviendo al menú principal...");
                return;
            case "9":
                if (ConfirmExitAndSave())
                {
                    SaveData();
                }
                Console.WriteLine("Gracias por usar la biblioteca.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    }
}

void MostrarTodo()
{
    byte opcion = 0;

    do
    {
        ShowMainMenu();
        string entrada = ReadText("Elije una opción del menú principal: ").Trim();

        if (!byte.TryParse(entrada, out opcion))
        {
            Console.WriteLine("Por favor, ingresa un número válido.");
            continue;
        }

        switch (opcion)
        {
            case 1:
                ManageBooksMenu();
                break;
            case 2:
                ManageUsersMenu();
                break;
            case 3:
                ManageLoansMenu();
                break;
            case 4:
                ManageSearchReportsMenu();
                break;
            case 5:
                ManagePersistenceMenu();
                break;
            case 6:
                if (ConfirmExitAndSave())
                {
                    SaveData();
                }
                Console.WriteLine("Gracias por usar la biblioteca.");
                break;
            default:
                Console.WriteLine("Opción no válida. Intenta nuevamente.");
                break;
        }
    } while (opcion != 6);
}

MostrarTodo();