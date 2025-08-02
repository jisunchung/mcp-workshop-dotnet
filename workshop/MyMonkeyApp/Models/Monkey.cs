namespace MyMonkeyApp.Models;

/// <summary>
/// 원숭이 종에 대한 정보를 나타내는 모델 클래스
/// </summary>
public class Monkey
{
    /// <summary>
    /// 원숭이의 이름
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 원숭이의 서식지 위치
    /// </summary>
    public required string Location { get; set; }

    /// <summary>
    /// 원숭이에 대한 상세 설명
    /// </summary>
    public required string Details { get; set; }

    /// <summary>
    /// 이미지 URL
    /// </summary>
    public required string Image { get; set; }

    /// <summary>
    /// 추정 개체수
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// 위도 좌표
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// 경도 좌표
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// 원숭이 정보를 포맷된 문자열로 반환
    /// </summary>
    /// <returns>포맷된 원숭이 정보</returns>
    public override string ToString()
    {
        return $"{Name} - {Location} (개체수: {Population:N0})";
    }

    /// <summary>
    /// 원숭이의 상세 정보를 표시
    /// </summary>
    /// <returns>상세 정보 문자열</returns>
    public string GetDetailedInfo()
    {
        return $"""
            🐒 {Name}
            📍 위치: {Location}
            👥 개체수: {Population:N0}마리
            🌍 좌표: {Latitude:F2}, {Longitude:F2}
            📖 설명: {Details}
            🖼️ 이미지: {Image}
            """;
    }

    /// <summary>
    /// 멸종 위험도를 평가
    /// </summary>
    /// <returns>위험도 상태</returns>
    public string GetConservationStatus()
    {
        return Population switch
        {
            < 500 => "심각한 멸종위기 🔴",
            < 2000 => "멸종위기 🟠",
            < 5000 => "취약 🟡",
            < 10000 => "준위협 🟢",
            _ => "안정 ✅"
        };
    }
}
