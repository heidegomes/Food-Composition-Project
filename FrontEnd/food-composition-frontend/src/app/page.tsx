// src/app/page.tsx
'use client';
import { useEffect, useState } from "react";
import FoodCard from "@/app/_components/FoodCard";

interface FoodData {
  Code: string;
  Name: string;
  ScientificName: string;
  Group: string;
  Component: string;
  Unit: string;
  ValuePer100g: string;
  StandardDeviation: string;
  MinimumValue: string;
  MaximumValue: string;
  NumberSamples: string;
  Reference: string;
  DataType: string;
}

const HomePage = () => {
  const [foodData, setFoodData] = useState<FoodData[]>([]);

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


  return (
    <div className="container mx-auto p-4">
      <h1 className="text-4xl font-bold text-center mb-8">Food Composition Data</h1>
      <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
        {foodData.map((food) => (
          <FoodCard key={food.Code} food={food} />
        ))}
      </div>
    </div>
  );
};

export default HomePage;
