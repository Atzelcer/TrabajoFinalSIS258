<?php

namespace App\Http\Controllers;

use App\Models\Pronostico;
use Illuminate\Http\Request;

class PronosticoController extends Controller
{
    public function index()
    {
        $pronosticos = Pronostico::all();
        
        return view('pronosticos.index', compact('pronosticos'));
    }

    public function store(Request $request)
    {
        $validated = $request->validate([
            'fecha' => 'required|string|max:10',
            'cantidad_estimada' => 'required|integer|min:0',
        ]);

        Pronostico::create($validated);

        return redirect()->route('pronosticos.index')
            ->with('success', 'Pronóstico creado exitosamente');
    }

    public function show($id)
    {
        $pronostico = Pronostico::findOrFail($id);

        return view('pronosticos.show', compact('pronostico'));
    }

    public function update(Request $request, $id)
    {
        $pronostico = Pronostico::findOrFail($id);

        $validated = $request->validate([
            'fecha' => 'required|string|max:10',
            'cantidad_estimada' => 'required|integer|min:0',
        ]);

        $pronostico->update($validated);

        return redirect()->route('pronosticos.index')
            ->with('success', 'Pronóstico actualizado exitosamente');
    }

    public function destroy($id)
    {
        $pronostico = Pronostico::findOrFail($id);

        $pronostico->delete();

        return redirect()->route('pronosticos.index')
            ->with('success', 'Pronóstico eliminado exitosamente');
    }

    public function create()
    {
        return view('pronosticos.create');
    }

    public function edit($id)
    {
        $pronostico = Pronostico::findOrFail($id);
        
        return view('pronosticos.edit', compact('pronostico'));
    }
}
