@extends('layouts.app')

@section('title', 'Lista de Pronósticos')

@section('content')
    <h1>Pronósticos de Demanda</h1>

    <div class="actions">
        <a href="{{ route('pronosticos.create') }}" class="btn btn-primary">Nuevo Pronóstico</a>
    </div>

    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>Fecha</th>
                <th>Cantidad Estimada</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            @forelse($pronosticos as $pronostico)
                <tr>
                    <td>{{ $pronostico->id }}</td>
                    <td>{{ $pronostico->fecha }}</td>
                    <td>{{ number_format($pronostico->cantidad_estimada) }}</td>
                    <td>
                        <a href="{{ route('pronosticos.show', $pronostico->id) }}" class="btn btn-primary">Ver</a>
                        <a href="{{ route('pronosticos.edit', $pronostico->id) }}" class="btn btn-warning">Editar</a>
                        <form action="{{ route('pronosticos.destroy', $pronostico->id) }}" method="POST" style="display:inline;">
                            @csrf
                            @method('DELETE')
                            <button type="submit" class="btn btn-danger" onclick="return confirm('¿Está seguro de eliminar este pronóstico?')">Eliminar</button>
                        </form>
                    </td>
                </tr>
            @empty
                <tr>
                    <td colspan="4" style="text-align:center;">No hay pronósticos registrados</td>
                </tr>
            @endforelse
        </tbody>
    </table>
@endsection
