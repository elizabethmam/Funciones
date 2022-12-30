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


//Pasando tipos de referencia: se modifica el valor original de la variable. La variable debe ser inicializada.

//Pasando un tipo valor, convirtiéndolo a tipo referencia para que se modifique el valor original de la variable.
int nuevaCantidad = 5;
void DuplicarValor(ref int n) //int se convierte a tipo referencia para que se modifique el valor original.
{
    n *= 2;
    Console.WriteLine($"El valor dentro de la función es: {n}");
}

Console.WriteLine($"El valor fuera de la función antes de invocarla, es: {nuevaCantidad}");
DuplicarValor(ref nuevaCantidad); //SIN ref, NO se pasa el valor original de la variable, sino una copia, por lo tanto no modifica su valor original. CON el ref, se pasa el valor original de la variable y se modifica su valor dentro y fuera de la función, pero después de invocarla. 
Console.WriteLine($"El valor fuera de la función después de invocar a la función, es: {nuevaCantidad}");


//Pasando un tipo de referencia originales como parámetro
//Los arreglos son de tipo referencia, por lo tanto, las alteraciones que reciban, se verán alteradas en la variable original.

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


//Parámetros con stings: los strings son inmutables, por lo tanto, no se modifica su valor original.

void Mayusculas (string nombre)
{
    nombre = nombre.ToUpper(); //crea un nuevo string, no modifica el string original
    Console.WriteLine($"El valor dentro de la función es: {nombre}");
}

string nombre2 = "Elizabéth";
Console.WriteLine($"El valor fuera de la función antes de invocarla, es: {nombre2}");
Mayusculas(nombre2);
Console.WriteLine($"El valor fuera de la función después de invocarla, es: {nombre2}");



// Out: es otra forma de pasar parámetros por referencia. La diferencia está en que "out" permite usar variables que NO han sido inicializadas.
//y el parámetro out dentro de la función debe ser tratado como NO INICIALIZADO.
//Out también permite obtener varios valores de una función.
// es obligatorio inicializar el parámetro out dento de la función antes de utilizarlo.
int cantidadSinInicializar; 

void Inicializar(int operando, out int outInicializar)
{
    operando *= 2;
    outInicializar = operando;
    Console.WriteLine($"El valor de la función, es: {outInicializar}");
}

Inicializar(3, out cantidadSinInicializar);
Console.WriteLine($"El valor fuera de la función, es: {cantidadSinInicializar}");


void DuplicarTriplicar(int operando, out int dupla, out int triple)
{
    dupla = operando * 2;
    triple = operando * 3;
}

int dupla, triple;
DuplicarTriplicar(3, out dupla, out triple);
Console.WriteLine($"La dupla es: {dupla} y el triple es: {triple}");


//Out en otros contextos:
// 1. TryParse() -> se intenta convertir un valor a otro tipo de dato y si ésto no se permite, entonces devuelve un valor boleano falso, en lugar de arrojar error.

int numeroOut;
string intentoNumero = "Eli";

if(int.TryParse(intentoNumero, out numeroOut))
{
    Console.WriteLine($"El número es {numeroOut}");
} else
{
    Console.WriteLine("Formato incorrecto.");
}


//Ejercicio
bool ObtenerMinMaxPromedio(int[] numeros, out int minimo, out int maximo, out double promedio)
{
    minimo = default;
    maximo = default;
    promedio = default;

    if (numeros.Length == 0 || numeros is null)
    {
        return false;
    }

    minimo = ObtenerMinimo(numeros);
    maximo = ObtenerMaximo(numeros);
    promedio = ObtenerPromedio(numeros);

    return true;
}

int ObtenerMinimo(int[] numeros)
{
    int minimoEntero = numeros[0];

    for(int i = 0; i < numeros.Length; i++)
    {
        if (minimoEntero > numeros[i])
        {
            minimoEntero = numeros[i];
        }
    }

    Console.WriteLine(minimoEntero);
    return minimoEntero;
}

int ObtenerMaximo(int[] numeros)
{
    int maximoEntero = numeros[0];

    for (int i = 0; i < numeros.Length; i++) {

        if (maximoEntero < numeros[i])
        {
            maximoEntero = numeros[i];
        }
    }

    Console.WriteLine(maximoEntero);
    return maximoEntero;
}

double ObtenerPromedio(int[] numeros)
{
    int suma = default;

    for (int i = 0; i < numeros.Length; i++)
    {
        suma += numeros[i];
    }

    Console.WriteLine(suma / numeros.Length);
    return suma / numeros.Length;

}


int[] arregloNumeros = new int[] { 5, 14, 28 };
int minimo;
int maximo;
double promedio;

ObtenerMinMaxPromedio(arregloNumeros, out minimo, out maximo, out promedio);


//Tuplas: conjunto de valores que podemos guardar en una variable (es similar a los arreglos). Permiten escribir un código más legible.
//Las tuplan también nos permiten combinar distintos tipos de datos en la colección.
//Muestra un error antes de la compilación si intentamos acceder a elementos que NO EXISTEN.
var tupla = (100, 45, "string");
Console.WriteLine(tupla);

//Acceder a los valores individuales de la tupla:
Console.WriteLine(tupla.Item1);
Console.WriteLine(tupla.Item2);
Console.WriteLine(tupla.Item3);

//tupla con etiquetas: es inicializar una tupla con los nombres y tipos de datos que contendrá la tupla.
(int edad, int idNumero, string nombreString) otraTupla = (20, 1, "otro string");
Console.WriteLine(otraTupla.edad);
Console.WriteLine(otraTupla.idNumero);
Console.WriteLine(otraTupla.nombreString);

//Las tuplas también pueden usarse como valores de salida de una función.
(int duplo, int triplo) FuncionTupla (int valor)
{
    return (valor * 2, valor * 3);
}

int cantidadDupla = 10;

FuncionTupla(cantidadDupla);

Console.WriteLine($"La cantidad es: {cantidadDupla}");
Console.WriteLine($"Su duplo es: {FuncionTupla(cantidadDupla).duplo}");
Console.WriteLine($"Su triplo es: {FuncionTupla(cantidadDupla).triplo}");