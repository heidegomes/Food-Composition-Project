import { NextResponse } from "next/server";

export async function GET() {
  const data = [
    {
      Code: "1234",
      Name: "Alimento 1",
      ScientificName: "Nome Científico 1",
      Group: "Grupo 1",
      Component: "Componente 1",
      Unit: "g",
      ValuePer100g: "10g",
      StandardDeviation: "0.5",
      MinimumValue: "9g",
      MaximumValue: "11g",
      NumberSamples: "100",
      Reference: "Estudo 1",
      DataType: "Média",
    },
    // Adicione mais alimentos conforme necessário
  ];

  return NextResponse.json(data);
}
