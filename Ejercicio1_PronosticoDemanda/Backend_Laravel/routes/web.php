<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\PronosticoController;

Route::get('/', function () {
    return redirect()->route('pronosticos.index');
});

Route::resource('pronosticos', PronosticoController::class);
