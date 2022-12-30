/*Funciones: piezas de código que se pueden reutilizar, lo cual permite organizar mejor el código.
También nos permite hacer un trabajo una vez y utilizarlo para siempre*/

//  Se debe especificar el tipo de dato que devuelve la función.
// Los paréntesis indican que es una función y que pueden recibir parámetros de entrada.
//Se debe devolver el tipo de dato con el que se inicializó la función, en este caso, un string.
// No todas las funciones deben retornar un valor, pues existen las funciones void.
//En las funciones se utiliza la notación de Pascal para declararlas
using System.Security.Cryptography;

string ObtenerNombre ()
{
    return "Elizabéth";
}

// Se invoca a la función y se puede invocar en cualquier lado, incluso en otra función.
Console.WriteLine(ObtenerNombre());

//Función que no retorna ningún valor
void FechaActual()
{
    DateTime fecha = DateTime.Now;
    string mensaje = $"Hoy es {fecha.ToString("dd-MM-yyyy")}";
    Console.WriteLine(mensaje);
}

FechaActual(); //siempre se debe invocar a las funciones, si no, no se ejecutarán nunca.

//Parámetros: valores de entrada a las funciones

int Duplicar (int valor)
{
    return valor * 2;
}

Duplicar(10);
Duplicar(3);

int Sumar (int suma1, int suma2)
{
    return suma1 + suma2;
}

Sumar(1, 2);


void RepetirMensaje (string mensaje, int veces)
{
    for (int i = 0; i < veces; i++)
    {
        Console.WriteLine(mensaje);
    }
}

RepetirMensaje("Éste es un mensaje", 5); //Siempre se debe respetar el orden de los parámetros.
RepetirMensaje(mensaje: "Éste es un mensaje", veces: 5); //parámetros nombrados; es mucho más legible.

//Imprimiento matrices
int[,] matriz = new int[,]
{
    {5, 6},
    {7, 8},
    {9, 10 }

};
void Matriz(int[,] matriz)
{

    for (int fila = 0; fila < matriz.GetLength(0); fila++)
    {
        for (int columna = 0; columna < matriz.GetLength(1); columna++)
        {
            Console.Write(matriz[fila, columna]);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}

Matriz(matriz);

//Parámetros opcionales: siempre van al final y se les debe poner un valor predeterminado en la función.
void Opcionales(string mensaje, bool mayusculas = true)
{
    if (mayusculas)
    {
        mensaje = mensaje.ToUpper();
    }

    Console.WriteLine(mensaje);
}

Opcionales("Elizabéth");
Opcionales("Yo puedo lograrlo");
Opcionales("Tengo hambre", false);

// Constantes en los parámetros opcionales: si se le va a pasar una variable a un parámetro opcional, debe ser una constante.
const bool parametroOpcional = true;
void OpcionalesConstante(string mensaje, bool mayusculas = parametroOpcional)
{
    if (mayusculas)
    {
        mensaje = mensaje.ToUpper();
    }

    Console.WriteLine(mensaje);
}

OpcionalesConstante("Es un ejemplo de una constante");
OpcionalesConstante("Son parámetros opcionales", false);

// Parámetro por default: si es parámetro es boleano, por defecto le pasa falso.
void UsandoDefault(string mensaje, bool isDefault = default)
{
    if (isDefault)
    {
        mensaje = mensaje.ToUpper();
    }

    Console.WriteLine(mensaje);
}

UsandoDefault("Se está usando default");
UsandoDefault("Se hace por defecto", true);

// Pasando arreglos como parámetros
double Promedio(int[] numeros)
{
    double suma = 0.0;

    foreach (int numero in numeros)
    {
        suma += numero;
    }

    return suma / numeros.Length;
}

Console.WriteLine($"El promedio es: {Promedio(new int[] { 1, 5, 7 })}");

//Params nos permite omitir new int[]: si hay más parámetros, el params debe ser el último parámetro, así como el default.
double UsandoParams(params int[] numeros)
{
    double suma = 0.0;

    foreach (int numero in numeros)
    {
        suma += numero;
    }

    return suma / numeros.Length;
}

Console.WriteLine($"Esta función está usando params {UsandoParams(1, 2, 5, 6)}");


//Pasando tipos de referencia: se modifica el valor original de la variable.

//Pasando un tipo valor, convirtiéndolo a tipo referencia para que se modifique el valor original de la variable.
int nuevaCantidad = 5;
void DuplicarValor(ref int n)
{
    n *= 2;
    Console.WriteLine($"El valor dentro de la función es: {n}");
}

Console.WriteLine($"El valor fuera de la función antes de invocarla, es: {nuevaCantidad}");
DuplicarValor(ref nuevaCantidad);
Console.WriteLine($"El valor fuera de la función después de invocar a la función, es: {nuevaCantidad}");


//Pasando un tipo de referencia como parámetro
//Los arreglos son de tipo referencia

int[] otroNumeroMas = new int[] {1, 2, 3};

void DuplicarArreglo (int[] numeros)
{
    for (int i = 0; i < numeros.Length; i++)
    {
        numeros[i] *= 2;
    }
}

void ArregloModificar(int[] numeros)
{
    foreach (int numero in numeros)
    {
        Console.Write($"{numero} ");
    }
}

Console.Write($"Valores del arreglo antes de la duplicación: ");
ArregloModificar(otroNumeroMas);
Console.WriteLine();

DuplicarArreglo(otroNumeroMas);

Console.Write($"Valores del arreglo después de la duplicación: ");
ArregloModificar(otroNumeroMas);


//Parámetros con stings: son inmutables, por lo tanto, no se modifica su valor original.

void Mayusculas (string nombre)
{
    nombre = nombre.ToUpper();
    Console.WriteLine($"El valor dentro de la función es: {nombre}");
}

string nombre2 = "Elizabéth";
Console.WriteLine($"El valor fuera de la función antes de invocarla, es: {nombre2}");
Mayusculas(nombre2);
Console.WriteLine($"El valor fuera de la función después de invocarla, es: {nombre2}");