using static Repository.Database.TStudent;

namespace WebAPI.Models.Student
{

  /// <summary>
  /// 創建學生API入參
  /// </summary>
  public class DtoCreateStudent
  {

    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///學號 
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// 性別
    /// </summary>
    public EnumGender Gender { get; set; }

 

    /// <summary>
    /// 電話
    /// </summary>
    public string Phone { get; set; }

  }
}
