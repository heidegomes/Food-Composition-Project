import type { NextConfig } from 'next';
import path from 'path';  // Importando o módulo path corretamente

const nextConfig: NextConfig = {
  webpack(config) {
    config.resolve.alias = {
      ...config.resolve.alias,
      '@': path.resolve(__dirname, 'src'),  // Usando path com import
    };
    return config;
  },
};

export default nextConfig;


