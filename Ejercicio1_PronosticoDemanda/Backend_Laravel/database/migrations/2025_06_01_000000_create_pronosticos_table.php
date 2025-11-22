<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    public function up(): void
    {
        Schema::create('pronosticos', function (Blueprint $table) {
            $table->id();
            $table->string('fecha', 10);
            $table->integer('cantidad_estimada');
            $table->timestamps();
        });
    }

    public function down(): void
    {
        Schema::dropIfExists('pronosticos');
    }
};
