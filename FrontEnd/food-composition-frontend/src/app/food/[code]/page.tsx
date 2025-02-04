'use client';
import { useEffect, useState } from "react";
import { useParams } from "next/navigation";
import { FoodData } from "@/app/types";

export default function FoodDetails() {
  const { code } = useParams<{ code: string }>();
  const [food, setFood] = useState<FoodData | null>(null);

  useEffect(() => {
    const fetchFoodDetails = async () => {
      try {
        const response = await fetch(`http://localhost:5057/api/food/${code}`);
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        setFood(data);
      } catch (error) {
        console.error("Erro ao buscar os detalhes do alimento:", error);
      }
    };
    fetchFoodDetails();
  }, [code]);

  if (!food) {
    return <div className="text-center mt-10">Carregando...</div>;
  }

  return (
    <div className="container mx-auto p-4">
      <div className="bg-green-200 border rounded-lg shadow-lg p-4">
        <h2 className="text-2xl font-bold text-green-900 mb-4">{food.name}</h2>
        <p className="text-sm text-green-900 mb-2">Código: {food.code}</p>
        <p className="text-sm text-green-900 mb-2">Nome Científico: {food.scientificName}</p>
        <p className="text-sm text-green-900 mb-4">Grupo: {food.group}</p>

        <div className="flex flex-col gap-4">
          {food.components.map((component) => (
            <div key={component.id} className="bg-green-100 border border-green-700 rounded-lg p-4 shadow-md">
              <h3 className="text-lg font-semibold text-green-900 mb-2">{component.component}</h3>
              <div className="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-2">
              <p className="text-sm text-green-800"><strong>Unidade:</strong> {component.unit}</p>
              <p className="text-sm text-green-800"><strong>Valor por 100g:</strong> {component.valuePer100g}</p>
              <p className="text-sm text-green-800"><strong>Desvio Padrão:</strong> {component.standardDeviation}</p>
              <p className="text-sm text-green-800"><strong>Valor Mínimo:</strong> {component.minValue}</p>
              <p className="text-sm text-green-800"><strong>Valor Máximo:</strong> {component.maxValue}</p>
              <p className="text-sm text-green-800"><strong>Nº de dados utilizados:</strong> {component.numberSamples}</p>
              <p className="text-sm text-green-800"><strong>Referências:</strong> {component.reference}</p>
              <p className="text-sm text-green-800"><strong>Tipo de Dados:</strong> {component.dataType}</p>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};