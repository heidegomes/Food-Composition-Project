'use client';
import { FoodData } from "@/app/types";
import Link from "next/link";

export default function FoodCard({
  food
}: {
  food: FoodData
}) {
  return (
    <Link href={`/food/${food.code}`}>
      <div className="bg-green-200 border rounded-lg shadow-lg p-4 flex flex-col">
        <h2 className="text-xl font-semibold text-green-900">{food.name}</h2>
        <div className="flex flex-col md:flex-row justify-between mt-2">
          <p className="text-sm text-green-900 font-bold">Código: {food.code}</p>
          <p className="text-sm text-green-900 font-bold">Nome Científico: {food.scientificName}</p>
          <p className="text-sm text-green-900 font-bold">Grupo: {food.group}</p>
        </div>
      </div>
    </Link>
  );
};

