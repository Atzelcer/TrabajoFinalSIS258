<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class PronosticoSeeder extends Seeder
{
    public function run(): void
    {
        $pronosticos = [
            ['fecha' => '01-06-25', 'cantidad_estimada' => 150],
            ['fecha' => '02-06-25', 'cantidad_estimada' => 145],
            ['fecha' => '03-06-25', 'cantidad_estimada' => 165],
            ['fecha' => '04-06-25', 'cantidad_estimada' => 170],
            ['fecha' => '05-06-25', 'cantidad_estimada' => 180],
            ['fecha' => '06-06-25', 'cantidad_estimada' => 130],
            ['fecha' => '07-06-25', 'cantidad_estimada' => 160],
            ['fecha' => '08-06-25', 'cantidad_estimada' => 190],
            ['fecha' => '09-06-25', 'cantidad_estimada' => 200],
        ];

        foreach ($pronosticos as $pronostico) {
            DB::table('pronosticos')->insert([
                'fecha' => $pronostico['fecha'],
                'cantidad_estimada' => $pronostico['cantidad_estimada'],
                'created_at' => now(),
                'updated_at' => now(),
            ]);
        }
    }
}
