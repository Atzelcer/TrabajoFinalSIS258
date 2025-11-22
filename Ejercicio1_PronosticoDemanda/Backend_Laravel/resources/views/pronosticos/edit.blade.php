@extends('layouts.app')

@section('title', 'Editar Pronóstico')

@section('content')
    <h1>Editar Pronóstico</h1>

    <form action="{{ route('pronosticos.update', $pronostico->id) }}" method="POST">
        @csrf
        @method('PUT')

        <div class="form-group">
            <label for="fecha">Fecha</label>
            <input type="text" id="fecha" name="fecha" value="{{ old('fecha', $pronostico->fecha) }}" placeholder="YYYY-MM-DD" required>
            @error('fecha')
                <span style="color: red;">{{ $message }}</span>
            @enderror
        </div>

        <div class="form-group">
            <label for="cantidad_estimada">Cantidad Estimada</label>
            <input type="number" id="cantidad_estimada" name="cantidad_estimada" value="{{ old('cantidad_estimada', $pronostico->cantidad_estimada) }}" min="0" required>
            @error('cantidad_estimada')
                <span style="color: red;">{{ $message }}</span>
            @enderror
        </div>

        <div class="actions">
            <button type="submit" class="btn btn-success">Actualizar</button>
            <a href="{{ route('pronosticos.index') }}" class="btn btn-danger">Cancelar</a>
        </div>
    </form>
@endsection
