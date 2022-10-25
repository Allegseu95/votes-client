using Aplicacion.Dominio.Entidades.Escrutinio;
using Shouldly;

namespace Aplicacion.Unit.Test.Dominio;
public class JRVPropiedadesTest
{
    [Fact]
    public void ObtenerId_RetornaId()
    {
        JRV sut = new() { Id = 1 };

        var resultado = sut.Id;

        resultado.ShouldBe(1);
    }

    [Fact]
    public void ObtenerId_NoRetornaNumeroDiferente()
    {
        JRV sut = new() { Id = 1 };

        var resultado = sut.Id;

        resultado.ShouldNotBe(10);
    }

    [Fact]
    public void ObtenerId_RetornaCero()
    {
        JRV sut = new();

        var resultado = sut.Id;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerId_RetornaTipoInt()
    {
        JRV sut = new();

        var resultado = sut.Id;

        resultado.ShouldBeOfType<int>();
    }
    [Fact]
    public void ObtenerId_NoRetornaTipoString()
    {
        JRV sut = new();

        var resultado = sut.Id;

        resultado.ShouldNotBeOfType<string>();
    }

    [Fact]
    public void ObtenerUsuarioId_RetornaUsuarioId()
    {
        JRV sut = new() { UsuarioId = 1 };

        var resultado = sut.UsuarioId;

        resultado.ShouldBe(1);
    }

    [Fact]
    public void ObtenerUsuarioId_NoRetornaNumeroDiferente()
    {
        JRV sut = new() { UsuarioId = 1 };

        var resultado = sut.UsuarioId;

        resultado.ShouldNotBe(10);
    }

    [Fact]
    public void ObtenerUsuarioId_RetornaCero()
    {
        JRV sut = new();

        var resultado = sut.UsuarioId;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerUsuarioId_RetornaTipoInt()
    {
        JRV sut = new();

        var resultado = sut.UsuarioId;

        resultado.ShouldBeOfType<int>();
    }
    [Fact]
    public void ObtenerUsuarioId_NoRetornaTipoString()
    {
        JRV sut = new();

        var resultado = sut.UsuarioId;

        resultado.ShouldNotBeOfType<string>();
    }
    [Fact]
    public void ObtenerNumero_RetornaNumero()
    {
        JRV sut = new() { Numero = 1 };

        var resultado = sut.Numero;

        resultado.ShouldBe(1);
    }

    [Fact]
    public void ObtenerNumero_NoRetornaNumeroDiferente()
    {
        JRV sut = new() { Numero = 1 };

        var resultado = sut.Numero;

        resultado.ShouldNotBe(10);
    }

    [Fact]
    public void ObtenerNumero_RetornaCero()
    {
        JRV sut = new();

        var resultado = sut.Numero;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerNumero_RetornaTipoInt()
    {
        JRV sut = new();

        var resultado = sut.Numero;

        resultado.ShouldBeOfType<int>();
    }
    [Fact]
    public void ObtenerNumero_NoRetornaTipoString()
    {
        JRV sut = new();

        var resultado = sut.Numero;

        resultado.ShouldNotBeOfType<string>();
    }
    [Fact]
    public void ObtenerGenero_RetornaGenero()
    {
        JRV sut = new() { Genero = "Masculino" };

        var resultado = sut.Genero;

        resultado.ShouldBe("Masculino");
    }

    [Fact]
    public void ObtenerGenero_NoRetornaVacio()
    {
        JRV sut = new() { Genero = "Masculino" };

        var resultado = sut.Genero;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerGenero_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.Genero;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerGenero_NoRetornaValorDiferente()
    {
        JRV sut = new() { Genero = "Masculino" };

        var resultado = sut.Genero;

        resultado.ShouldNotBe("Femenino");
    }
    [Fact]
    public void ObtenerGenero_RetornaTipoString()
    {
        JRV sut = new() { Genero = "Masculino" };

        var resultado = sut.Genero;

        resultado.ShouldBeOfType<string>();
    }
    [Fact]
    public void ObtenerDireccionRecinto_RetornaDireccionRecinto()
    {
        JRV sut = new() { DireccionRecinto = "Calle 13 y Av. 13" };

        var resultado = sut.DireccionRecinto;

        resultado.ShouldBe("Calle 13 y Av. 13");
    }

    [Fact]
    public void ObtenerDireccionRecinto_NoRetornaVacio()
    {
        JRV sut = new() { DireccionRecinto = "Calle 13 y Av. 13" };

        var resultado = sut.DireccionRecinto;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerDireccionRecinto_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.DireccionRecinto;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerDireccionRecinto_NoRetornaValorDiferente()
    {
        JRV sut = new() { DireccionRecinto = "Calle 13 y Av. 13" };

        var resultado = sut.DireccionRecinto;

        resultado.ShouldNotBe("Calle 14 y Av. 15");
    }
    [Fact]
    public void ObtenerDireccionRecinto_RetornaTipoString()
    {
        JRV sut = new() { DireccionRecinto = "Calle 13 y Av. 13" };

        var resultado = sut.DireccionRecinto;

        resultado.ShouldBeOfType<string>();
    }
    [Fact]
    public void ObtenerRecinto_RetornaRecinto()
    {
        JRV sut = new() { Recinto = "Colegio Manta" };

        var resultado = sut.Recinto;

        resultado.ShouldBe("Colegio Manta");
    }

    [Fact]
    public void ObtenerRecinto_NoRetornaVacio()
    {
        JRV sut = new() { Recinto = "Colegio Manta" };

        var resultado = sut.Recinto;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerRecinto_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.Recinto;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerRecinto_NoRetornaValorDiferente()
    {
        JRV sut = new() { Recinto = "Colegio Manta" };

        var resultado = sut.Recinto;

        resultado.ShouldNotBe("Colegio Tarqui");
    }
    [Fact]
    public void ObtenerRecinto_RetornaTipoString()
    {
        JRV sut = new() { Recinto = "Colegio Manta" };

        var resultado = sut.Recinto;

        resultado.ShouldBeOfType<string>();
    }

    [Fact]
    public void ObtenerZonaElectoral_RetornaZonaElectoral()
    {
        JRV sut = new() { ZonaElectoral = "Sector Tarqui" };

        var resultado = sut.ZonaElectoral;

        resultado.ShouldBe("Sector Tarqui");
    }

    [Fact]
    public void ObtenerZonaElectoral_NoRetornaVacio()
    {
        JRV sut = new() { ZonaElectoral = "Sector Tarqui" };

        var resultado = sut.ZonaElectoral;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerZonaElectoral_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.ZonaElectoral;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerZonaElectoral_NoRetornaValorDiferente()
    {
        JRV sut = new() { ZonaElectoral = "Sector Tarqui" };

        var resultado = sut.ZonaElectoral;

        resultado.ShouldNotBe("Sector Universidad");
    }
    [Fact]
    public void ObtenerZonaElectoral_RetornaTipoString()
    {
        JRV sut = new() { ZonaElectoral = "Sector Tarqui" };

        var resultado = sut.ZonaElectoral;

        resultado.ShouldBeOfType<string>();
    }

    [Fact]
    public void ObtenerParroquia_RetornaParroquia()
    {
        JRV sut = new() { Parroquia = "Tarqui" };

        var resultado = sut.Parroquia;

        resultado.ShouldBe("Tarqui");
    }

    [Fact]
    public void ObtenerParroquia_NoRetornaVacio()
    {
        JRV sut = new() { Parroquia = "Tarqui" };

        var resultado = sut.Parroquia;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerParroquia_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.Parroquia;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerParroquia_NoRetornaValorDiferente()
    {
        JRV sut = new() { Parroquia = "Tarqui" };

        var resultado = sut.Parroquia;

        resultado.ShouldNotBe("Esteros");
    }
    [Fact]
    public void ObtenerParroquia_RetornaTipoString()
    {
        JRV sut = new() { Parroquia = "Tarqui" };

        var resultado = sut.Parroquia;

        resultado.ShouldBeOfType<string>();
    }
    [Fact]
    public void ObtenerTipoParroquia_RetornaTipoParroquia()
    {
        JRV sut = new() { TipoParroquia = "Urbana" };

        var resultado = sut.TipoParroquia;

        resultado.ShouldBe("Urbana");
    }

    [Fact]
    public void ObtenerTipoParroquia_NoRetornaVacio()
    {
        JRV sut = new() { TipoParroquia = "Urbana" };

        var resultado = sut.TipoParroquia;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerTipoParroquia_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.TipoParroquia;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerTipoParroquia_NoRetornaValorDiferente()
    {
        JRV sut = new() { TipoParroquia = "Urbana" };

        var resultado = sut.TipoParroquia;

        resultado.ShouldNotBe("Rural");
    }
    [Fact]
    public void ObtenerTipoParroquia_RetornaTipoString()
    {
        JRV sut = new() { TipoParroquia = "Urbana" };

        var resultado = sut.TipoParroquia;

        resultado.ShouldBeOfType<string>();
    }

    [Fact]
    public void ObtenerCanton_RetornaCanton()
    {
        JRV sut = new() { Canton = "Manta" };

        var resultado = sut.Canton;

        resultado.ShouldBe("Manta");
    }

    [Fact]
    public void ObtenerCanton_NoRetornaVacio()
    {
        JRV sut = new() { Canton = "Manta" };

        var resultado = sut.Canton;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerCanton_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.Canton;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerCanton_NoRetornaValorDiferente()
    {
        JRV sut = new() { Canton = "Manta" };

        var resultado = sut.Canton;

        resultado.ShouldNotBe("Montecristi");
    }
    [Fact]
    public void ObtenerCanton_RetornaTipoString()
    {
        JRV sut = new() { Canton = "Manta" };

        var resultado = sut.Canton;

        resultado.ShouldBeOfType<string>();
    }
    [Fact]
    public void ObtenerCircunscripcion_RetornaCircunscripcion()
    {
        JRV sut = new() { Circunscripcion = "Zona Norte - 1" };

        var resultado = sut.Circunscripcion;

        resultado.ShouldBe("Zona Norte - 1");
    }

    [Fact]
    public void ObtenerCircunscripcion_NoRetornaVacio()
    {
        JRV sut = new() { Circunscripcion = "Zona Norte - 1" };

        var resultado = sut.Circunscripcion;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerCircunscripcion_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.Circunscripcion;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerCircunscripcion_NoRetornaValorDiferente()
    {
        JRV sut = new() { Circunscripcion = "Zona Norte - 1" };

        var resultado = sut.Circunscripcion;

        resultado.ShouldNotBe("Zona Sur - 2");
    }
    [Fact]
    public void ObtenerCircunscripcion_RetornaTipoString()
    {
        JRV sut = new() { Circunscripcion = "Zona Norte - 1" };

        var resultado = sut.Circunscripcion;

        resultado.ShouldBeOfType<string>();
    }
    
    [Fact]
    public void ObtenerProvincia_RetornaProvincia()
    {
        JRV sut = new() { Provincia = "Manabí" };

        var resultado = sut.Provincia;

        resultado.ShouldBe("Manabí");
    }

    [Fact]
    public void ObtenerProvincia_NoRetornaVacio()
    {
        JRV sut = new() { Provincia = "Manabí" };

        var resultado = sut.Provincia;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerProvincia_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.Provincia;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerProvincia_NoRetornaValorDiferente()
    {
        JRV sut = new() { Provincia = "Manabí" };

        var resultado = sut.Provincia;

        resultado.ShouldNotBe("Pichincha");
    }
    [Fact]
    public void ObtenerProvincia_RetornaTipoString()
    {
        JRV sut = new() { Provincia = "Manabí" };

        var resultado = sut.Provincia;

        resultado.ShouldBeOfType<string>();
    }

    [Fact]
    public void ObtenerCantidadVotantes_RetornaCantidadVotantes()
    {
        JRV sut = new() { CantidadVotantes = 350 };

        var resultado = sut.CantidadVotantes;

        resultado.ShouldBe(350);
    }

    [Fact]
    public void ObtenerCantidadVotantes_NoRetornaNumeroDiferente()
    {
        JRV sut = new() { CantidadVotantes = 350 };

        var resultado = sut.CantidadVotantes;

        resultado.ShouldNotBe(360);
    }

    [Fact]
    public void ObtenerCantidadVotantes_RetornaCero()
    {
        JRV sut = new();

        var resultado = sut.CantidadVotantes;

        resultado.ShouldBe(0);
    }

    [Fact]
    public void ObtenerCantidadVotantes_RetornaTipoInt()
    {
        JRV sut = new();

        var resultado = sut.CantidadVotantes;

        resultado.ShouldBeOfType<int>();
    }
    [Fact]
    public void ObtenerCantidadVotantes_NoRetornaTipoString()
    {
        JRV sut = new();

        var resultado = sut.CantidadVotantes;

        resultado.ShouldNotBeOfType<string>();
    }

    [Fact]
    public void ObtenerCreado_RetornaCreado()
    {
        JRV sut = new() { Creado = new DateTime(2022, 9, 12) };

        var resultado = sut.Creado;

        resultado.ShouldBe(new DateTime(2022, 9, 12));
    }  
    [Fact]
    public void ObtenerCreado_RetornaFechaMenor_Igual()
    {
        JRV sut = new() { Creado = new DateTime(2022, 9, 12) };

        var resultado = sut.Creado;

        resultado.ShouldBeLessThanOrEqualTo(DateTime.Now);
    }
    [Fact]
    public void ObtenerCreado_NoRetornaValorDiferente()
    {
        JRV sut = new() { Creado = new DateTime(2022, 9, 12) };

        var resultado = sut.Creado;

        resultado.ShouldNotBe(new DateTime(2022, 10, 12));
    }  
    [Fact]
    public void ObtenerCreado_RetornaTipoDateTime()
    {
        JRV sut = new() { Creado = new DateTime(2022, 9, 12) };

        var resultado = sut.Creado;

        resultado.ShouldBeOfType<DateTime>();
    }
    [Fact]
    public void ObtenerModificado_RetornaModificado()
    {
        JRV sut = new() { Modificado = new DateTime(2022, 9, 12) };

        var resultado = sut.Modificado;

        resultado.ShouldBe(new DateTime(2022, 9, 12));
    }  
    [Fact]
    public void ObtenerModificado_RetornaFechaMenor_Igual()
    {
        JRV sut = new() { Modificado = new DateTime(2022, 9, 12) };

        var resultado = sut.Modificado;

        resultado.ShouldBeLessThanOrEqualTo(DateTime.Now);
    }
    [Fact]
    public void ObtenerModificado_NoRetornaValorDiferente()
    {
        JRV sut = new() { Modificado = new DateTime(2022, 9, 12) };

        var resultado = sut.Modificado;

        resultado.ShouldNotBe(new DateTime(2022, 10, 12));
    }  
    [Fact]
    public void ObtenerModificado_RetornaTipoDateTime()
    {
        JRV sut = new() { Modificado = new DateTime(2022, 9, 12) };

        var resultado = sut.Modificado;

        resultado.ShouldBeOfType<DateTime>();
    }

    [Fact]
    public void ObtenerCreadoPor_RetornaCreadoPor()
    {
        JRV sut = new() { CreadoPor = "Usuario Actual 1" };

        var resultado = sut.CreadoPor;

        resultado.ShouldBe("Usuario Actual 1");
    }

    [Fact]
    public void ObtenerCreadoPor_NoRetornaVacio()
    {
        JRV sut = new() { CreadoPor = "Usuario Actual 1" };

        var resultado = sut.CreadoPor;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerCreadoPor_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.CreadoPor;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerCreadoPor_NoRetornaValorDiferente()
    {
        JRV sut = new() { CreadoPor = "Usuario Actual 1" };

        var resultado = sut.CreadoPor;

        resultado.ShouldNotBe("Usuario Actual 2");
    }
    [Fact]
    public void ObtenerCreadoPor_RetornaTipoString()
    {
        JRV sut = new() { CreadoPor = "Usuario Actual 1" };

        var resultado = sut.CreadoPor;

        resultado.ShouldBeOfType<string>();
    }

    [Fact]
    public void ObtenerModificadoPor_RetornaModificadoPor()
    {
        JRV sut = new() { ModificadoPor = "Usuario Actual 1" };

        var resultado = sut.ModificadoPor;

        resultado.ShouldBe("Usuario Actual 1");
    }

    [Fact]
    public void ObtenerModificadoPor_NoRetornaVacio()
    {
        JRV sut = new() { ModificadoPor = "Usuario Actual 1" };

        var resultado = sut.ModificadoPor;

        resultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerModificadoPor_NoRetornaNull()
    {
        JRV sut = new();

        var resultado = sut.ModificadoPor;

        resultado.ShouldNotBeNull();
    }

    [Fact]
    public void ObtenerModificadoPor_NoRetornaValorDiferente()
    {
        JRV sut = new() { ModificadoPor = "Usuario Actual 1" };

        var resultado = sut.ModificadoPor;

        resultado.ShouldNotBe("Usuario Actual 2");
    }
    [Fact]
    public void ObtenerModificadoPor_RetornaTipoString()
    {
        JRV sut = new() { ModificadoPor = "Usuario Actual 1" };

        var resultado = sut.ModificadoPor;

        resultado.ShouldBeOfType<string>();
    }
}
