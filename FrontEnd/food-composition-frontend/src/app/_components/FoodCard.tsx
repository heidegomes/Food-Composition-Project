'use client';
import { FC } from "react";

interface FoodData {
  code: string;
  name: string;
  scientificName: string;
  group: string;
  component: string;
  unit: string;
  valuePer100g: string;
  standardDeviation: string;
  minimumValue: string;
  maximumValue: string;
  numberSamples: string;
  reference: string;
  dataType: string;
}

interface FoodCardProps {
  food: FoodData;
}

const FoodCard: FC<FoodCardProps> = ({ food }) => {
  return (
    <div className="bg-white border rounded-lg shadow-lg p-4 flex flex-col">
      <h2 className="text-xl font-semibold text-gray-800">{food.name}</h2>
      <p className="text-sm text-gray-600">{food.scientificName}</p>
      <p className="text-sm text-gray-500">{food.group}</p>

      <div className="mt-4 space-y-2">
        <div className="flex justify-between">
          <span className="font-semibold">Component:</span>
          <span>{food.component}</span>
        </div>
        <div className="flex justify-between">
          <span className="font-semibold">Unit:</span>
          <span>{food.unit}</span>
        </div>
        <div className="flex justify-between">
          <span className="font-semibold">Value per 100g:</span>
          <span>{food.valuePer100g}</span>
        </div>
        <div className="flex justify-between">
          <span className="font-semibold">Standard Deviation:</span>
          <span>{food.standardDeviation}</span>
        </div>
        <div className="flex justify-between">
          <span className="font-semibold">Min Value:</span>
          <span>{food.minimumValue}</span>
        </div>
        <div className="flex justify-between">
          <span className="font-semibold">Max Value:</span>
          <span>{food.maximumValue}</span>
        </div>
        <div className="flex justify-between">
          <span className="font-semibold">Number of Samples:</span>
          <span>{food.numberSamples}</span>
        </div>
        <div className="flex justify-between">
          <span className="font-semibold">Reference:</span>
          <span>{food.reference}</span>
        </div>
        <div className="flex justify-between">
          <span className="font-semibold">Data Type:</span>
          <span>{food.dataType}</span>
        </div>
      </div>
    </div>
  );
};

export default FoodCard;
