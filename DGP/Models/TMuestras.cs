public class TMuestras
{
public int ID { get; set; }
public Laboratorios Laboratorio {get;set;}
public string codigo_muestra { get; set; }
public string nombre_paciente{ get; set; }
public string apellido_paciente { get; set; }
public string sexo { get; set; }
public string fecha_nacimiento { get; set; }
public string tipo_documento { get; set; }
public string numero_documento { get; set; }
public string codigo_nacionalidad { get; set; }
public Manejo manejo {get;set;}
public string codigo_tipo_atencion { get; set; }
public Provincias Provincia {get;set;}
public string codigo_municipio { get; set; }
public string codigo_sector { get; set; }
public string direccion { get; set; }
public string telefono { get; set; }
public string celular { get; set; }
public string tiene_sintomas { get; set; }
public string embarazada { get; set; }
public string fecha_toma_muestra { get; set; }
public string fecha_reporte { get; set; }
public string resultado { get; set; }
public string tipo_muestra { get; set; }
public string primera_muestra { get; set; }
public string comentarios { get; set; }



}