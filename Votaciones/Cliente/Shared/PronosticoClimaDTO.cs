namespace Cliente.Shared;

public record PronosticoClimaDto(DateTime Fecha, int TemperaturaC, string? Resumen, int TemperaturaF);