@extends('layouts.app')

@section('title', 'Detalle del Pronóstico')

@section('content')
    <h1>Detalle del Pronóstico</h1>

    <div style="background: #f8f9fa; padding: 20px; border-radius: 5px; margin: 20px 0;">
        <p><strong>ID:</strong> {{ $pronostico->id }}</p>
        <p><strong>Fecha:</strong> {{ $pronostico->fecha }}</p>
        <p><strong>Cantidad Estimada:</strong> {{ number_format($pronostico->cantidad_estimada) }}</p>
        <p><strong>Creado:</strong> {{ $pronostico->created_at->format('d/m/Y H:i') }}</p>
        <p><strong>Actualizado:</strong> {{ $pronostico->updated_at->format('d/m/Y H:i') }}</p>
    </div>

    <div class="actions">
        <a href="{{ route('pronosticos.edit', $pronostico->id) }}" class="btn btn-warning">Editar</a>
        <a href="{{ route('pronosticos.index') }}" class="btn btn-primary">Volver al Listado</a>
        <form action="{{ route('pronosticos.destroy', $pronostico->id) }}" method="POST" style="display:inline;">
            @csrf
            @method('DELETE')
            <button type="submit" class="btn btn-danger" onclick="return confirm('¿Está seguro de eliminar este pronóstico?')">Eliminar</button>
        </form>
    </div>
@endsection
