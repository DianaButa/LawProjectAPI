namespace LawProject.DTO
{
  public class AllFilesDto
  {
    // Informații din baza de date (CreateFileDTO)
    public int Id { get; set; }
    public string FileNumber { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string TipDosar { get; set; } = string.Empty;

    public string LawyerName { get; set; } = string.Empty;

    // Informații din SOAP (FileDetailsDTO)
    public string Numar { get; set; }
    public string NumarVechi { get; set; }
    public DateTime Data { get; set; }
    public string Institutie { get; set; }
    public string Departament { get; set; }
    public string CategorieCaz { get; set; }
    public string StadiuProcesual { get; set; }
    public List<ParteDTO> Parti { get; set; }
    public List<SedintaDTO> Sedinte { get; set; }
    public List<CaleAtacDTO> CaiAtac { get; set; }
  }
}
