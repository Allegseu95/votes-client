
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Nito.AsyncEx;

namespace Aplicacion.Integracion.Test.Comun;


public abstract class IntegrationTestBase : IAsyncLifetime
{
    private static readonly AsyncLock mutex = new();

    private static bool initialized;

    private readonly SliceFixture fixture;

    protected IntegrationTestBase(SliceFixture fixture)
    {
        this.fixture = fixture;
    }

    public virtual async Task InitializeAsync()
    {
        if (initialized)
            return;

        using (await mutex.LockAsync())
        {
            if (initialized)
                return;

            await this.fixture.ResetCheckpoint();

            initialized = true;
        }
    }

    public virtual async Task DisposeAsync() =>
        //await SliceFixture.ResetCheckpoint();
        await Task.CompletedTask;
}

