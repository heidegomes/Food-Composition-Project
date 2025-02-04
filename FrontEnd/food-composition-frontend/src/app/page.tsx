'use client';
import { useEffect, useState } from "react";
import FoodCard from "@/app/_components/FoodCard";
import { FoodData } from "@/app/types";

export default function HomePage(){
  const [foodData, setFoodData] = useState<FoodData[]>([]);
  const [searchTerm, setSearchTerm] = useState<string>("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:5057/api/food");
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        setFoodData(data);
      } catch (error) {
        console.error("Erro ao buscar os dados:", error);
      }
    };
    fetchData();
  }, []);

  const filteredFoods = foodData.filter(food =>
    food.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-4xl text-green-200 font-bold text-center mt-8">Composição Química</h1>
      <h1 className="text-2xl text-green-200 placeholder:font-bold text-center mb-8">(Informação Estatística)</h1>
      <input
        type="text"
        placeholder="Pesquisar alimentos..."
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        className="w-full p-2 mb-4 border rounded-lg bg-green-100 placeholder-green-900/50"
      />
      <div className="flex flex-col gap-6">
        {filteredFoods.map((food) => (
          <FoodCard key={food.code} food={food} />
        ))}
      </div>
    </div>
  );
};

