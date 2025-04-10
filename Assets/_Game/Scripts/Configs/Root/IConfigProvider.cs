
using System.Threading.Tasks;

public interface IConfigProvider
{
    // ����� ���� ������ ���������� �������.
    // � ������� �� ������ ���� � ���������� ����������

    GameConfig GameConfig { get; }
    Task<GameConfig> LoadGameConfig();
}