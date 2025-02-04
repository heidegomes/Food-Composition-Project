export type Components = {
  id: number;
  component: string;
  unit: string;
  valuePer100g: string;
  standardDeviation: string;
  minValue: string;
  maxValue: string;
  numberSamples: string;
  reference: string;
  dataType: string;
};

export type FoodData = {
  code: string;
  name: string;
  scientificName: string;
  group: string;
  components: Components[];
};
